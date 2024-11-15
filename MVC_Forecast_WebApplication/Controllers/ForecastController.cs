using Microsoft.AspNetCore.Mvc;
using MVC_Forecast_WebApplication.Models;
using MVC_Forecast_WebApplication.Models.ForecastModels;
using Newtonsoft.Json;
using RestSharp;

namespace MVC_Forecast_WebApplication.Controllers
{
    public class ForecastController : Controller
    {
        private readonly IConfiguration _configuration;

        public ForecastController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int pg = 1)
        {

            // Injecting configuration values from appsettings.json
            var baseURL = _configuration.GetValue<string>("Settings:BaseURL");
            var path = _configuration.GetValue<string>("Settings:Route");

            var route = new RestRequest(path, RestSharp.Method.Get);

            var client = new RestClient(baseURL);
            var httpResponse = await client.ExecuteAsync(route);

            // Verify if the HTTP response is successful
            if (httpResponse.IsSuccessStatusCode)
            {
                var content = httpResponse.Content;

                var rootClassDeserialized = JsonConvert.DeserializeObject<Root>(content);
                var forecastPeriods = rootClassDeserialized.properties.periods.ToList();

                const int pageSize = 13;

                if (pg < 1)
                    pg = 1;

                int recsCount = forecastPeriods.Count();

                var pager = new Pager(recsCount, pg, pageSize);

                int recSkip = (pg -1 ) * pageSize;

                var data = forecastPeriods.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                return View(data);
            }

            return new BadRequestObjectResult(httpResponse.ErrorException);


        }

    }
}
