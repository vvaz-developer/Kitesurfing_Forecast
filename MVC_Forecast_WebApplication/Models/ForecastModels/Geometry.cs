﻿namespace MVC_Forecast_WebApplication.Models.ForecastModels
{
    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<double?>>> coordinates { get; set; }
    }
}
