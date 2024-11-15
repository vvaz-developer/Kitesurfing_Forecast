using Microsoft.AspNetCore.Mvc;

namespace MVC_Forecast_WebApplication.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
