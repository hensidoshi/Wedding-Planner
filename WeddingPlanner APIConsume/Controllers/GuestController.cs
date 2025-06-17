using Microsoft.AspNetCore.Mvc;
using WeddingPlanner_APIConsume.Models;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeddingPlanner_APIConsume.Controllers
{
    public class GuestController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public GuestController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }

        #region GuestList
        public async Task<IActionResult> GuestList()
        {
            var response = await _httpClient.GetAsync("api/Guests");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var guests = JsonConvert.DeserializeObject<List<GuestsModel>>(data);
                return View(guests);
            }
            return View(new List<GuestsModel>());
        }
        #endregion

        #region WeddingDropDown
        public async Task WeddingDropDown()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Guests/weddings");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var weddings = JsonConvert.DeserializeObject<List<WeddingDropDownModel>>(jsonData);
                ViewBag.WeddingList = weddings;
            }
        }
        #endregion

        #region GuestAddEdit
        public async Task<IActionResult> GuestAddEdit(int? GuestID)
        {
            await WeddingDropDown();
            if (GuestID.HasValue)
            {
                var response = await _httpClient.GetAsync($"api/Guests/{GuestID}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var guest = JsonConvert.DeserializeObject<GuestsModel>(data);
                    return View(guest);
                }
            }
            return View(new GuestsModel());
        }
        #endregion

        #region GuestSave
        [HttpPost]
        public async Task<IActionResult> Save(GuestsModel guest)
        {
            await WeddingDropDown();
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(guest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (guest.GuestID == null)
                    response = await _httpClient.PostAsync("api/Guests", content);
                else
                    response = await _httpClient.PutAsync($"api/Guests/{guest.GuestID}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = guest.GuestID == null
                        ? "Guest successfully added."
                        : "Guest successfully updated.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Operation failed. Please try again.";
                }

                return RedirectToAction("GuestList");
            }
            return View("GuestAddEdit", guest);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int GuestID)
        {
            var response = await _httpClient.DeleteAsync($"api/Guests/{GuestID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteSuccessMessage"] = "Guest deleted successfully.";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Failed to delete the guest.";
            }
            return RedirectToAction("GuestList");
        }
        #endregion
    }
}
