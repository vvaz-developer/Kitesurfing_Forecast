using Microsoft.AspNetCore.Mvc;

namespace MVC_Forecast_WebApplication.Controllers
{
    public class KitesurfingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
