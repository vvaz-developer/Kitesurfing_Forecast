namespace MVC_Forecast_WebApplication.Models.ForecastModels
{
    public class Properties
    {
        public string units { get; set; }
        public string forecastGenerator { get; set; }
        public DateTime? generatedAt { get; set; }
        public DateTime? updateTime { get; set; }
        public string validTimes { get; set; }
        public Elevation elevation { get; set; }
        public List<Period> periods { get; set; }
    }
}
