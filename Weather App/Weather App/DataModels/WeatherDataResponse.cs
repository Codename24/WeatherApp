using System;
using Newtonsoft.Json;

namespace Weather_App.Models
{
    public class WeatherDataResponse
    {
        [JsonProperty(PropertyName = "main")] 
        public Main MainData { get; set; }
        
        [JsonProperty(PropertyName = "wind")] 
        public Wind WindData { get; set; }

        [JsonProperty(PropertyName = "dt_txt")]
        public DateTime CurrentDate { get; set; }
    }
}