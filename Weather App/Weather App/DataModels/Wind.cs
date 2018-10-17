using Newtonsoft.Json;

namespace Weather_App.Models
{
    public class Wind
    {
        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }
        
        [JsonProperty(PropertyName = "deg")]
        public  double Degree { get; set; }
    }
}