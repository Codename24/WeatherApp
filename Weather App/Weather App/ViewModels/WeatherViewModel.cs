using System.Collections.Generic;

namespace Weather_App.ViewModels
{
    public class WeatherViewModel
    {
        public string CityName { get; set; }
        public IEnumerable<WeatherDetailsViewModel> WeatherDetails { get; set; }
    }
}