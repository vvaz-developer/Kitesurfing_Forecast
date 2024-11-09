using Microsoft.AspNetCore.Mvc;
using MVC_Forecast_WebApplication.Models.ForecastModels;
using Newtonsoft.Json;
using RestSharp;

namespace MVC_Forecast_WebApplication.Controllers
{
    public class ForecastController : Controller
    {
        private readonly IConfiguration _config;

        public ForecastController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            // Injecting configuration values from appsettings.json
            var baseURL = _config.GetValue<string>("Settings:BaseURL");
            var path = _config.GetValue<string>("Settings:Route");

            var route = new RestRequest(path, RestSharp.Method.Get);

            var client = new RestClient(baseURL);
            var httpResponse = await client.ExecuteAsync(route);


            if (httpResponse.IsSuccessStatusCode)
            {
                var content = httpResponse.Content;

                var rootClassDeserialized = JsonConvert.DeserializeObject<Root>(content);
                var forecastPeriods = rootClassDeserialized.properties.periods;

                var forecastPeriodList = new List<Period>(forecastPeriods);

                return View(forecastPeriodList.ToList());
            }

            return new BadRequestObjectResult(httpResponse.ErrorException);


        }

    }
}
