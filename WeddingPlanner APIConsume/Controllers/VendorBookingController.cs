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
    public class VendorBookingController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public VendorBookingController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }

        #region VendorBookingList
        public async Task<IActionResult> VendorBookingList()
        {
            var response = await _httpClient.GetAsync("api/VendorBookings");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var vendorBookings = JsonConvert.DeserializeObject<List<VendorBookingsModel>>(data);
                return View(vendorBookings);
            }
            return View(new List<VendorBookingsModel>());
        }
        #endregion

        #region WeddingDropDown
        public async Task WeddingDropDown()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/VendorBookings/weddings");
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
            HttpResponseMessage response = await _httpClient.GetAsync("api/VendorBookings/vendors");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var vendors = JsonConvert.DeserializeObject<List<VendorDropDownModel>>(jsonData);
                ViewBag.VendorList = vendors;
            }
        }
        #endregion

        #region VendorBookingAddEdit
        public async Task<IActionResult> VendorBookingAddEdit(int? VendorBookingID)
        {
            await WeddingDropDown();
            await VendorDropDown();
            if (VendorBookingID.HasValue)
            {
                var response = await _httpClient.GetAsync($"api/VendorBookings/{VendorBookingID}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var vendorBooking = JsonConvert.DeserializeObject<VendorBookingsModel>(data);
                    return View(vendorBooking);
                }
            }
            return View(new VendorBookingsModel());
        }
        #endregion

        #region VendorBookingSave
        [HttpPost]
        public async Task<IActionResult> Save(VendorBookingsModel vendorBooking)
        {
            await WeddingDropDown();
            await VendorDropDown();
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(vendorBooking);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (vendorBooking.BookingID == null)
                    response = await _httpClient.PostAsync("api/VendorBookings", content);
                else
                    response = await _httpClient.PutAsync($"api/VendorBookings/{vendorBooking.BookingID}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = vendorBooking.BookingID == null
                        ? "Vendor booking successfully added."
                        : "Vendor booking successfully updated.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Operation failed. Please try again.";
                }
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error Response: {errorContent}");
                return RedirectToAction("VendorBookingList");
            }
            return View("VendorBookingAddEdit", vendorBooking);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int VendorBookingID)
        {
            var response = await _httpClient.DeleteAsync($"api/VendorBookings/{VendorBookingID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteSuccessMessage"] = "Vendor booking deleted successfully.";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Failed to delete the vendor booking.";
            }
            return RedirectToAction("VendorBookingList");
        }
        #endregion
    }
}
