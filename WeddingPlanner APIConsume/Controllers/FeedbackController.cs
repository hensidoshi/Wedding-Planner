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
    public class FeedbackController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public FeedbackController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }

        #region FeedbackList
        public async Task<IActionResult> FeedbackList()
        {
            var response = await _httpClient.GetAsync("api/Feedbacks");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var feedbacks = JsonConvert.DeserializeObject<List<FeedbacksModel>>(data);
                return View(feedbacks);
            }
            return View(new List<FeedbacksModel>());
        }
        #endregion

        #region ClientDropDown
        public async Task ClientDropDown()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Feedbacks/clients");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var clients = JsonConvert.DeserializeObject<List<ClientDropDownModel>>(jsonData);
                ViewBag.ClientList = clients;
            }
        }
        #endregion

        #region WeddingDropDown
        public async Task WeddingDropDown()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Feedbacks/weddings");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var weddings = JsonConvert.DeserializeObject<List<WeddingDropDownModel>>(jsonData);
                ViewBag.WeddingList = weddings;
            }
        }
        #endregion

        #region FeedbackAddEdit
        public async Task<IActionResult> FeedbackAddEdit(int? FeedbackID)
        {
            await ClientDropDown();
            await WeddingDropDown();
            if (FeedbackID.HasValue)
            {
                var response = await _httpClient.GetAsync($"api/Feedbacks/{FeedbackID}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var feedbacks = JsonConvert.DeserializeObject<FeedbacksModel>(data);
                    return View(feedbacks);
                }
            }
            return View(new FeedbacksModel());
        }
        #endregion

        #region FeedbackSave
        [HttpPost]
        public async Task<IActionResult> Save(FeedbacksModel feedback)
        {
            await ClientDropDown();
            await WeddingDropDown();
            if (ModelState.IsValid)
            {
                //if(wedding.WeddingID ==null)
                //{
                //    wedding.WeddingID = 0;
                //}
                var json = JsonConvert.SerializeObject(feedback);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (feedback.FeedbackID == null)
                    response = await _httpClient.PostAsync("api/Feedbacks", content);
                else
                    response = await _httpClient.PutAsync($"api/Feedbacks/{feedback.FeedbackID}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = feedback.FeedbackID == null
                        ? "Feedback successfully added."
                        : "Feedback successfully updated.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Operation failed. Please try again.";
                }

                return RedirectToAction("FeedbackList");
            }
            return View("FeedbackAddEdit", feedback);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int FeedbackID)
        {
            var response = await _httpClient.DeleteAsync($"api/Feedbacks/{FeedbackID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteSuccessMessage"] = "Feedback deleted successfully.";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Failed to delete the wedding.";
            }
            return RedirectToAction("FeedbackList");
        }
        #endregion
    }
}
