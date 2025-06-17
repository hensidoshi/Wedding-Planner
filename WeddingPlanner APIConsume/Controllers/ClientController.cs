using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WeddingPlanner_APIConsume.Models;

namespace WeddingPlanner_APIConsume.Controllers
{
    public class ClientController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public ClientController(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
            };
        }

        #region ClientList
        public async Task<IActionResult> ClientList()
        {
            var response = await _httpClient.GetAsync("api/Clients");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var clients = JsonConvert.DeserializeObject<List<ClientsModel>>(data);
                return View(clients);
            }
            return View(new List<ClientsModel>());
        }
        #endregion

        #region ClientAddEdit
        public async Task<IActionResult> ClientAddEdit(int? ClientID)
        {
            if (ClientID.HasValue)
            {
                var response = await _httpClient.GetAsync($"api/Clients/{ClientID}");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var client = JsonConvert.DeserializeObject<ClientsModel>(data);
                    return View(client);
                }
            }
            return View(new ClientsModel());
        }
        #endregion

        #region ClientSave
        [HttpPost]
        public async Task<IActionResult> Save(ClientsModel client)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(client);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response;

                if (client.ClientID == null)
                    response = await _httpClient.PostAsync("api/Clients", content);
                else
                    response = await _httpClient.PutAsync($"api/Clients/{client.ClientID}", content);

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = client.ClientID == null
                        ? "Client successfully added."
                        : "Client successfully updated.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Operation failed. Please try again.";
                }

                return RedirectToAction("ClientList");
            }
            return View("ClientAddEdit", client);
        }
        #endregion

        #region ClientDelete
        public async Task<IActionResult> Delete(int ClientID)
        {
            var response = await _httpClient.DeleteAsync($"api/Clients/{ClientID}");
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteSuccessMessage"] = "Client deleted successfully.";
            }
            else
            {
                TempData["DeleteErrorMessage"] = "Failed to delete the customer.";
            }
            return RedirectToAction("ClientList");
        }
        #endregion
    }
}

