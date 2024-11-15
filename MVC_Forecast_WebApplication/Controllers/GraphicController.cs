using Microsoft.AspNetCore.Mvc;

namespace MVC_Forecast_WebApplication.Controllers
{
    public class GraphicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
