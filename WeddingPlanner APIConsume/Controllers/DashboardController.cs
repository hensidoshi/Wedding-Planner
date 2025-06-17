using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WeddingPlanner_APIConsume.Models;
using WeddingPlanner_APIConsume.Service;

public class DashboardController : Controller
{
    private readonly ApiService _apiService;

    public DashboardController(ApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> DashboardUi()
    {
        var weddings = await _apiService.GetWeddingsAsync();
        var clients = await _apiService.GetClientsAsync();
        var vendors = await _apiService.GetVendorsAsync();
        var feedbacks = await _apiService.GetFeedbacksAsync();
        var tasks = await _apiService.GetTasksAsync(); // Make sure your ApiService has this method

        // Store counts in ViewBag
        ViewBag.TotalWeddings = weddings.Count;
        ViewBag.TotalClients = clients.Count;
        ViewBag.TotalVendors = vendors.Count;
        ViewBag.TotalFeedbacks = feedbacks.Count;

        // Get the 5 most recent weddings (ordered by wedding date)
        ViewBag.RecentWeddings = weddings
           .OrderByDescending(w => w.WeddingDate)
           .Take(5)
           .ToList();

        // Get the 5 most recent tasks (ordered by deadline)
        ViewBag.RecentTasks = tasks
           .Take(11)
           .ToList();

        // If you have venues/destinations, you can add them here as well:
        // ViewBag.Venues = await _apiService.GetVenuesAsync();

        return View();
    }
}
