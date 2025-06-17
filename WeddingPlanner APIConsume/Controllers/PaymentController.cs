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
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }

        #region PaymentList
        public async Task<IActionResult> PaymentList()
        {
            var response = await _httpClient.GetAsync("api/Payments");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var payments = JsonConvert.DeserializeObject<List<PaymentsModel>>(data);
                return View(payments);
            }
            return View(new List<PaymentsModel>());
        }
        #endregion

        #region WeddingDropDown
        public async Task WeddingDropDown()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Payments/weddings");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var weddings = JsonConvert.DeserializeObject<List<WeddingDropDownModel>>(jsonData);
                ViewBag.WeddingList = weddings;
            }
        }
        #endregion

        #region VendorDropDown
        public async Task VendorDropDown()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Payments/vendors");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var vendors = JsonConvert.DeserializeObject<List<VendorDropDownModel>>(jsonData);
                ViewBag.VendorList = vendors;
            }
        }
        #endregion


        #region PaymentAddEdit
        public async Task<IActionResult> PaymentAddEdit(int? PaymentID)
        {
            await WeddingDropDown();
            await VendorDropDown();
            if (PaymentID.HasValue)
            {
                var response = await _httpClient.GetAsync($"api/Payments/{PaymentID}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var payment = JsonConvert.DeserializeObject<PaymentsModel>(data);
                    return View(payment);
                }
            }
            return View(new PaymentsModel());
        }
        #endregion

        #region PaymentSave
        [HttpPost]
        public async Task<IActionResult> Save(PaymentsModel payment)
        {
            await WeddingDropDown();
            await VendorDropDown();
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(payment);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (payment.PaymentID == null)
                    response = await _httpClient.PostAsync("api/Payments", content);
                else
                    response = await _httpClient.PutAsync($"api/Payments/{payment.PaymentID}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = payment.PaymentID == null
                        ? "Payment successfully added."
                        : "Payment successfully updated.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Operation failed. Please try again.";
                }
                return RedirectToAction("PaymentList");
            }
            return View("PaymentAddEdit", payment);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int PaymentID)
        {
            var response = await _httpClient.DeleteAsync($"api/Payments/{PaymentID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteSuccessMessage"] = "Payment deleted successfully.";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Failed to delete the payment.";
            }
            return RedirectToAction("PaymentList");
        }
        #endregion
    }
}