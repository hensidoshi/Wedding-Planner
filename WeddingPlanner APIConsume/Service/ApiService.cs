using Newtonsoft.Json;
using WeddingPlanner_APIConsume.Models;

namespace WeddingPlanner_APIConsume.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<WeddingsModel>> GetWeddingsAsync()
        {
            var response = await _httpClient.GetStringAsync("http://localhost:5176/api/Weddings");
            return JsonConvert.DeserializeObject<List<WeddingsModel>>(response);
        }
        public async Task<List<ClientsModel>> GetClientsAsync()
        {
            var response = await _httpClient.GetStringAsync("http://localhost:5176/api/Clients");
            return JsonConvert.DeserializeObject<List<ClientsModel>>(response);
        }
        public async Task<List<VendorsModel>> GetVendorsAsync()
        {
            var response = await _httpClient.GetStringAsync("http://localhost:5176/api/Vendors");
            return JsonConvert.DeserializeObject<List<VendorsModel>>(response);
        }
        public async Task<List<FeedbacksModel>> GetFeedbacksAsync()
        {
            var response = await _httpClient.GetStringAsync("http://localhost:5176/api/Feedbacks");
            return JsonConvert.DeserializeObject<List<FeedbacksModel>>(response);
        }
        public async Task<List<TasksModel>> GetTasksAsync()
        {
            var response = await _httpClient.GetStringAsync("http://localhost:5176/api/Tasks");
            return JsonConvert.DeserializeObject<List<TasksModel>>(response);
        }

    }
}
