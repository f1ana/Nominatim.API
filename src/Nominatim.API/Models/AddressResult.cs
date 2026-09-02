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
        ///     County name 县
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
        ///     Town Name 城镇
        /// </summary>
        [JsonProperty("town")]
        public string Town { get; set; }

        /// <summary>
        ///     Pedestrian 步行
        /// </summary>
        [JsonProperty("pedestrian")]
        public string Pedestrian { get; set; }

        /// <summary>
        ///     Neighbourhood 街区
        /// </summary>
        [JsonProperty("neighbourhood")]
        public string Neighborhood { get; set; }

        /// <summary>
        ///     Hamlet 村庄
        /// </summary>
        [JsonProperty("hamlet")]
        public string Hamlet { get; set; }

        /// <summary>
        ///     Suburb
        /// </summary>
        [JsonProperty("suburb")]
        public string Suburb { get; set; }

        /// <summary>
        ///     Village Name 村庄
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
        ///     District Name 区
        /// </summary>
        [JsonProperty("district")]
        public string District { get; set; }

        /// <summary>
        ///     Name of the entity/road in given location
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Tourism 旅游区
        /// </summary>
        [JsonProperty("tourism")]
        public string Tourism { get; set; }

        /// <summary>
        ///     Municipality 市
        /// </summary>
        [JsonProperty("municipality")]
        public string Municipality { get; set; }

        /// <summary>
        ///     Quarter 街区
        /// </summary>
        [JsonProperty("quarter")]
        public string Quarter { get; set; }

        /// <summary>
        ///     Residential 住宅区
        /// </summary>
        [JsonProperty("residential")]
        public string Residential { get; set; }

        /// <summary>
        ///     Amenity 设施
        /// </summary>
        [JsonProperty("amenity")]
        public string Amenity { get; set; }

        /// <summary>
        ///     Military 军事区
        /// </summary>
        [JsonProperty("military")]
        public string Military { get; set; }

        /// <summary>
        ///     Building 建筑
        /// </summary>
        [JsonProperty("building")]
        public string Building { get; set; }
    }
}