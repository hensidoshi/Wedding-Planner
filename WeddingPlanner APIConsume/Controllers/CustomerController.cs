using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WeddingPlanner_APIConsume.Models;

namespace WeddingPlanner_APIConsume.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }

        #region CustomerList
        public async Task<IActionResult> CustomerList()
        {
            var response = await _httpClient.GetAsync("api/Customers");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<CustomersModel>>(data);
                return View(customers);
            }
            return View(new List<CustomersModel>());
        }
        #endregion

        #region CustomerAddEdit
        public async Task<IActionResult> CustomerAddEdit(int? CustomerID)
        {
            if (CustomerID.HasValue)
            {
                var response = await _httpClient.GetAsync($"api/Customers/{CustomerID}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var customer = JsonConvert.DeserializeObject<CustomersModel>(data);
                    return View(customer);
                }
            }
            return View(new CustomersModel());
        }
        #endregion

        #region CustomerSave
        [HttpPost]
        public async Task<IActionResult> Save(CustomersModel customer)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(customer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (customer.CustomerID == null)
                    response = await _httpClient.PostAsync("api/Customers", content);
                else
                    response = await _httpClient.PutAsync($"api/Customers/{customer.CustomerID}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = customer.CustomerID == null
                        ? "Customer successfully added."
                        : "Customer successfully updated.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Operation failed. Please try again.";
                }

                return RedirectToAction("CustomerList");
            }
            return View("CustomerAddEdit", customer);
        }
        #endregion

        #region CustomerDelete
        public async Task<IActionResult> Delete(int CustomerID)
        {
            var response = await _httpClient.DeleteAsync($"api/Customers/{CustomerID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteSuccessMessage"] = "Customer deleted successfully.";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Failed to delete the customer.";
            }
            return RedirectToAction("CustomerList");
        }
        #endregion
    }
}
