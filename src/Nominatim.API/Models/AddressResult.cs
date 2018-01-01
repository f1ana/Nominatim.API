using Newtonsoft.Json;

namespace Nominatim.API.Models {
    public class AddressResult {
        /// <summary>
        ///     Country name
        /// </summary>
        [JsonProperty("country")]
        public string Country { get; set; }

        /// <summary>
        ///     Country code
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        ///     County name
        /// </summary>
        [JsonProperty("county")]
        public string County { get; set; }

        /// <summary>
        ///     House Number
        /// </summary>
        [JsonProperty("house_number")]
        public string HouseNumber { get; set; }

        /// <summary>
        ///     Postal code
        /// </summary>
        [JsonProperty("postcode")]
        public string PostCode { get; set; }

        /// <summary>
        ///     Road Name
        /// </summary>
        [JsonProperty("road")]
        public string Road { get; set; }

        /// <summary>
        ///     State Name
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        ///     Town Name
        /// </summary>
        [JsonProperty("town")]
        public string Town { get; set; }

        [JsonProperty("pedestrian")]
        public string Pedestrian { get; set; }

        /// <summary>
        ///     Neighborhood
        /// </summary>
        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }

        /// <summary>
        ///     Hamlet
        /// </summary>
        [JsonProperty("hamlet")]
        public string Hamlet { get; set; }

        /// <summary>
        ///     Suburb
        /// </summary>
        [JsonProperty("suburb")]
        public string Suburb { get; set; }

        /// <summary>
        ///     Village Name
        /// </summary>
        [JsonProperty("village")]
        public string Village { get; set; }

        /// <summary>
        ///     City Name
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        ///     Region Name
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        ///     District Name
        /// </summary>
        [JsonProperty("state_district")]
        public string District { get; set; }

        /// <summary>
        ///     Name of the entity/road in given location
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}