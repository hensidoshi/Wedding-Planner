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
    public class WeddingController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public WeddingController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }

        #region WeddingList
        public async Task<IActionResult> WeddingList()
        {
            var response = await _httpClient.GetAsync("api/Weddings");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var weddings = JsonConvert.DeserializeObject<List<WeddingsModel>>(data);
                return View(weddings);
            }
            return View(new List<WeddingsModel>());
        }
        #endregion

        #region ClientDropDown
        public async Task ClientDropDown()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Weddings/clients");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var clients = JsonConvert.DeserializeObject<List<ClientDropDownModel>>(jsonData);
                ViewBag.ClientList = clients;
            }
        }
        #endregion

        #region WeddingAddEdit
        public async Task<IActionResult> WeddingAddEdit(int? WeddingID)
        {
            await ClientDropDown();
            if (WeddingID.HasValue)
            {
                var response = await _httpClient.GetAsync($"api/Weddings/{WeddingID}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var wedding = JsonConvert.DeserializeObject<WeddingsModel>(data);
                    return View(wedding);
                }
            }
            return View(new WeddingsModel());
        }
        #endregion

        #region WeddingSave
        [HttpPost]
        public async Task<IActionResult> Save(WeddingsModel wedding)
        {
            await ClientDropDown();
            if (ModelState.IsValid)
            {
                //if(wedding.WeddingID ==null)
                //{
                //    wedding.WeddingID = 0;
                //}
                var json = JsonConvert.SerializeObject(wedding);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (wedding.WeddingID == null)
                    response = await _httpClient.PostAsync("api/Weddings", content);
                else
                    response = await _httpClient.PutAsync($"api/Weddings/{wedding.WeddingID}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = wedding.WeddingID == null
                        ? "Wedding successfully added."
                        : "Wedding successfully updated.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Operation failed. Please try again.";
                }

                return RedirectToAction("WeddingList");
            }
            return View("WeddingAddEdit", wedding);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int WeddingID)
        {
            var response = await _httpClient.DeleteAsync($"api/Weddings/{WeddingID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteSuccessMessage"] = "Wedding deleted successfully.";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Failed to delete the wedding.";
            }
            return RedirectToAction("WeddingList");
        }
        #endregion
    }
}

