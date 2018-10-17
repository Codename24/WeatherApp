using Newtonsoft.Json;

namespace Weather_App.Models
{
    public class CurrentWeatherResponse
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "main")]
        public Main MainData { get; set; }
        
        [JsonProperty(PropertyName = "wind")]
        public Wind WindData { get; set; }
        
    }
}