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
    public class ExpenseController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public ExpenseController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }

        #region ExpenseList
        public async Task<IActionResult> ExpenseList()
        {
            var response = await _httpClient.GetAsync("api/Expenses");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var expenses = JsonConvert.DeserializeObject<List<ExpensesModel>>(data);
                return View(expenses);
            }
            return View(new List<ExpensesModel>());
        }
        #endregion

        #region WeddingDropDown
        public async Task WeddingDropDown()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Expenses/weddings");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var weddings = JsonConvert.DeserializeObject<List<WeddingDropDownModel>>(jsonData);
                ViewBag.WeddingList = weddings;
            }
        }
        #endregion

        #region ExpenseAddEdit
        public async Task<IActionResult> ExpenseAddEdit(int? ExpenseID)
        {
            await WeddingDropDown();
            if (ExpenseID.HasValue)
            {
                var response = await _httpClient.GetAsync($"api/Expenses/{ExpenseID}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var expense = JsonConvert.DeserializeObject<ExpensesModel>(data);
                    return View(expense);
                }
            }
            return View(new ExpensesModel());
        }
        #endregion

        #region ExpenseSave
        [HttpPost]
        public async Task<IActionResult> Save(ExpensesModel expense)
        {
            await WeddingDropDown();
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(expense);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (expense.ExpenseID == null)
                    response = await _httpClient.PostAsync("api/Expenses", content);
                else
                    response = await _httpClient.PutAsync($"api/Expenses/{expense.ExpenseID}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = expense.ExpenseID == null
                        ? "Expense successfully added."
                        : "Expense successfully updated.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Operation failed. Please try again.";
                }
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error Response: {errorContent}");

                return RedirectToAction("ExpenseList");
            }
            return View("ExpenseAddEdit", expense);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int ExpenseID)
        {
            var response = await _httpClient.DeleteAsync($"api/Expenses/{ExpenseID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteSuccessMessage"] = "Expense deleted successfully.";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Failed to delete the expense.";
            }
            return RedirectToAction("ExpenseList");
        }
        #endregion
    }
}
