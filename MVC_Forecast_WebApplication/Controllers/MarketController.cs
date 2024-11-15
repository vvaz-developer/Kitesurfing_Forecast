using Microsoft.AspNetCore.Mvc;

namespace MVC_Forecast_WebApplication.Controllers
{
    public class MarketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
