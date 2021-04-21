using System.Text.Json;
using System.Text.Json.Serialization;

namespace Nominatim.NetCore.API.Models {
    public class AddressResult {
        /// <summary>
        ///     Country name
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        ///     Country code
        /// </summary>
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        ///     County name
        /// </summary>
        [JsonPropertyName("county")]
        public string County { get; set; }

        /// <summary>
        ///     House Number
        /// </summary>
        [JsonPropertyName("house_number")]
        public string HouseNumber { get; set; }

        /// <summary>
        ///     Postal code
        /// </summary>
        [JsonPropertyName("postcode")]
        public string PostCode { get; set; }

        /// <summary>
        ///     Road Name
        /// </summary>
        [JsonPropertyName("road")]
        public string Road { get; set; }

        /// <summary>
        ///     State Name
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        ///     Town Name
        /// </summary>
        [JsonPropertyName("town")]
        public string Town { get; set; }

        [JsonPropertyName("pedestrian")]
        public string Pedestrian { get; set; }

        /// <summary>
        ///     Neighborhood
        /// </summary>
        [JsonPropertyName("neighborhood")]
        public string Neighborhood { get; set; }

        /// <summary>
        ///     Hamlet
        /// </summary>
        [JsonPropertyName("hamlet")]
        public string Hamlet { get; set; }

        /// <summary>
        ///     Suburb
        /// </summary>
        [JsonPropertyName("suburb")]
        public string Suburb { get; set; }

        /// <summary>
        ///     Village Name
        /// </summary>
        [JsonPropertyName("village")]
        public string Village { get; set; }

        /// <summary>
        ///     City Name
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        ///     Region Name
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        ///     District Name
        /// </summary>
        [JsonPropertyName("state_district")]
        public string District { get; set; }

        /// <summary>
        ///     Name of the entity/road in given location
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}