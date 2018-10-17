using Newtonsoft.Json;

namespace Weather_App.Models
{
    public class Main
    {
        [JsonProperty(PropertyName = "temp")] 
        public double Temperature { get; set; }
        
        [JsonProperty(PropertyName = "humidity")] 
        public double Humidity { get; set; }
    }
}