using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using WeddingPlanner_APIConsume.Models;

namespace WeddingPlanner_APIConsume.Controllers
{
    public class UserPanelController : Controller
    {
		private readonly IConfiguration _configuration;
		private readonly HttpClient _httpClient;

		public UserPanelController(IConfiguration configuration)
		{
			_configuration = configuration;
			_httpClient = new HttpClient
			{
				BaseAddress = new System.Uri(_configuration["WebApiBaseUrl"])
			};
		}

		public IActionResult Home()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Story()
		{
			return View();
        }
		public async Task<IActionResult> Family()
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
		public async Task<IActionResult> Gallery()
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
        public async Task<IActionResult> Event()
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
        public IActionResult Contact()
        {
            return View();
        }
	}
}
