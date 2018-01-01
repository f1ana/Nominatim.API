using Newtonsoft.Json;

namespace Nominatim.API.Models {
    public class AddressResult {
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("county")]
        public string County { get; set; }
        [JsonProperty("house_number")]
        public string HouseNumber { get; set; }
        [JsonProperty("postcode")]
        public string PostCode { get; set; }
        [JsonProperty("road")]
        public string Road { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("town")]
        public string Town { get; set; }
    }
}