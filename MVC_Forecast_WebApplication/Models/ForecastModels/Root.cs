using Newtonsoft.Json;

namespace MVC_Forecast_WebApplication.Models.ForecastModels
{
    public class Root
    {
        [JsonProperty("@context")]
        public List<object> context { get; set; }
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }
}
