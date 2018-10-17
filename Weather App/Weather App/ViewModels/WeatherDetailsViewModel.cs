using System;

namespace Weather_App.ViewModels
{
    public class WeatherDetailsViewModel
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public DateTime CalculationDate { get; set; } 
    }
}