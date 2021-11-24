using Newtonsoft.Json;

namespace Company.DataProviders.Models
{
    public class Location
    {
        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }
    }
}