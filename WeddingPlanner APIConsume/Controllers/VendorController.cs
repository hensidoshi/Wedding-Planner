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
    public class VendorController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public VendorController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }

        #region VendorList
        public async Task<IActionResult> VendorList()
        {
            var response = await _httpClient.GetAsync("api/Vendors");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var vendors = JsonConvert.DeserializeObject<List<VendorsModel>>(data);
                return View(vendors);
            }
            return View(new List<VendorsModel>());
        }
        #endregion

        #region VendorAddEdit
        public async Task<IActionResult> VendorAddEdit(int? VendorID)
        {
            if (VendorID.HasValue)
            {
                var response = await _httpClient.GetAsync($"api/Vendors/{VendorID}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var vendor = JsonConvert.DeserializeObject<VendorsModel>(data);
                    return View(vendor);
                }
            }
            return View(new VendorsModel());
        }
        #endregion

        #region VendorSave
        [HttpPost]
        public async Task<IActionResult> Save(VendorsModel vendor)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(vendor);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (vendor.VendorID == null)
                    response = await _httpClient.PostAsync("api/Vendors", content);
                else
                    response = await _httpClient.PutAsync($"api/Vendors/{vendor.VendorID}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = vendor.VendorID == null
                        ? "Vendor successfully added."
                        : "Vendor successfully updated.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Operation failed. Please try again.";
                }

                return RedirectToAction("VendorList");
            }
            return View("VendorAddEdit", vendor);
        }
        #endregion

        #region VendorDelete
        public async Task<IActionResult> Delete(int VendorID)
        {
            var response = await _httpClient.DeleteAsync($"api/Vendors/{VendorID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteSuccessMessage"] = "Vendor deleted successfully.";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Failed to delete the vendor.";
            }
            return RedirectToAction("VendorList");
        }
        #endregion
    }
}
