﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WeddingPlanner_APIConsume.Models;

namespace WeddingPlanner_APIConsume.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }

        #region UserList
        public async Task<IActionResult> UserList()
        {
            var response = await _httpClient.GetAsync("api/Users");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<UsersModel>>(data);
                return View(users);
            }
            return View(new List<UsersModel>());
        }
        #endregion

        #region UserAddEdit
        public async Task<IActionResult> UserAddEdit(int? UserID)
        {
            if (UserID.HasValue)
            {
                var response = await _httpClient.GetAsync($"api/Users/{UserID}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var user = JsonConvert.DeserializeObject<UsersModel>(data);
                    return View(user);
                }
            }
            return View(new UsersModel());
        }
        #endregion

        #region UserSave
        [HttpPost]
        public async Task<IActionResult> Save(UsersModel user)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (user.UserID == null)
                    response = await _httpClient.PostAsync("api/Users", content);
                else
                    response = await _httpClient.PutAsync($"api/Users/{user.UserID}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = user.UserID == null
                        ? "User successfully added."
                        : "User successfully updated.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Operation failed. Please try again.";
                }

                return RedirectToAction("UserList");
            }
            return View("UserAddEdit", user);
        }
        #endregion

        #region UserDelete
        public async Task<IActionResult> Delete(int UserID)
        {
            var response = await _httpClient.DeleteAsync($"api/Users/{UserID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteSuccessMessage"] = "User deleted successfully.";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Failed to delete the user.";
            }
            return RedirectToAction("UserList");
        }
        #endregion
    }
}
