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
    public class TaskController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public TaskController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }

        #region TaskList
        public async Task<IActionResult> TaskList()
        {
            var response = await _httpClient.GetAsync("api/Tasks");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var tasks = JsonConvert.DeserializeObject<List<TasksModel>>(data); 
                return View(tasks);
            }
            return View(new List<TasksModel>());
        }
        #endregion

        #region WeddingDropDown
        public async Task WeddingDropDown()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Tasks/weddings");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var weddings = JsonConvert.DeserializeObject<List<WeddingDropDownModel>>(jsonData);
                ViewBag.WeddingList = weddings;
            }
        }
        #endregion

        #region TaskAddEdit
        public async Task<IActionResult> TaskAddEdit(int? TaskID)
        {
            await WeddingDropDown();
            if (TaskID.HasValue)
            {
                var response = await _httpClient.GetAsync($"api/Tasks/{TaskID}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var task = JsonConvert.DeserializeObject<TasksModel>(data); 
                    return View(task);
                }
            }
            return View(new TasksModel());
        }
        #endregion

        #region TaskSave
        [HttpPost]
        public async Task<IActionResult> Save(TasksModel task)
        {
            await WeddingDropDown(); 
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(task);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (task.TaskID == null)
                    response = await _httpClient.PostAsync("api/Tasks", content); 
                else
                    response = await _httpClient.PutAsync($"api/Tasks/{task.TaskID}", content); 

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = task.TaskID == null
                        ? "Task successfully added."
                        : "Task successfully updated.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Operation failed. Please try again.";
                }
                return RedirectToAction("TaskList");
            }
            return View("TaskAddEdit", task);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int TaskID)
        {
            var response = await _httpClient.DeleteAsync($"api/Tasks/{TaskID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteSuccessMessage"] = "Task deleted successfully.";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Failed to delete the task.";
            }
            return RedirectToAction("TaskList");
        }
        #endregion
    }
}
