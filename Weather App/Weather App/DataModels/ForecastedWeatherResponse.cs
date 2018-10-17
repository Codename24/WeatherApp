using System.Collections.Generic;
using Newtonsoft.Json;

namespace Weather_App.Models
{
    public class ForecastedWeatherResponse
    {
        [JsonProperty(PropertyName = "city")]
        public City CityInfo { get; set; }
        
        [JsonProperty(PropertyName = "list")]
        public IEnumerable<WeatherDataResponse> WeatherDataList { get; set; }
    }
}