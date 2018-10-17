using Newtonsoft.Json;

namespace Weather_App.Models
{
    public class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}