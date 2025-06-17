using Microsoft.AspNetCore.Mvc;

namespace WeddingPlanner_APIConsume.Controllers
{
    public class PanelController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult User()
        {
            return View();
        }
    }
}
