using Microsoft.AspNetCore.Mvc;

namespace BigDataOrdersDashboard.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
