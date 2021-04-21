using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Nominatim.NetCore.API.JsonConverters;

namespace Nominatim.NetCore.API.Models {
    public class BaseNominatimResponse {
        /// <summary>
        /// Unique ID for this element
        /// </summary>
        [JsonPropertyName("place_id")]
        public int PlaceID { get; set; }

        /// <summary>
        /// The License and attribution requirements
        /// </summary>
        [JsonPropertyName("licence")]
        public string License { get; set; }

        /// <summary>
        /// The type of this element. One of node way relation.
        /// </summary>
        [JsonPropertyName("osm_type")]
        public string OSMType { get; set; }

        /// <summary>
        /// The OSM ID of this element type.
        /// </summary>
        [JsonPropertyName("osm_id")]
        public long OSMID { get; set; }

        /// <summary>
        /// The Latitude of this element
        /// </summary>
        [JsonPropertyName("lat")]
        [JsonConverter(typeof(InfoToDoubleConverter))]
        public double Latitude { get; set; }

        /// <summary>
        /// The Longitude of this element
        /// </summary>
        [JsonPropertyName("lon")]
        [JsonConverter(typeof(InfoToDoubleConverter))]
        public double Longitude { get; set; }

        /// <summary>
        /// The display name of this element, with complete address
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The extratags defined for this element. Returned when extratags=1 is set in the request.
        /// </summary>
        [JsonPropertyName("extratags")]
        public IDictionary<string, string> ExtraTags { get; set; }

        /// <summary>
        /// The names defined in other languages for this element. Returned when namedetails=1 is set in the request.
        /// </summary>
        [JsonPropertyName("namedetails")]
        public IDictionary<string, string> AlternateNames { get; set; }

        /// <summary>
        /// The address breakdown into individual components. Returned when addressdetails=1 is set in the request. Important components include (but not limited to) country, country_code, postcode, state, county, city, town.
        /// </summary>
        [JsonPropertyName("address")]
        public AddressResult Address { get; set; }

        /// <summary>
        /// The category of this element
        /// </summary>
        [JsonPropertyName("class")]
        public string Class { get; set; }

        /// <summary>
        /// Calculated importance of this element compared to the search query the user has provided. Ranges between 0 and 1.
        /// </summary>
        [JsonPropertyName("importance")]
        [JsonConverter(typeof(InfoToDoubleConverter))]
        public double Importance { get; set; }

        /// <summary>
        /// The URL of an icon representing this element, if applicable.
        /// </summary>
        [JsonPropertyName("icon")]
        public string IconURL { get; set; }

        // Below the extentions for jsonv2 responses

        /// <summary>
        /// The category of this element, if applicable.
        /// Replaces the "class" from jsonv1
        /// </summary>
        /// 
        [JsonPropertyName("category")]
        public string Category { get; set; }

        /// <summary>
        /// The 'type' of the category of this element
        /// </summary>
        [JsonPropertyName("type")]
        public string ClassType { get; set; }
      
        /// <summary>
        /// The addresstype of this element like road, xxx , if applicable.
        /// </summary>
        /// 
        [JsonPropertyName("addresstype")]
        public string Addresstype { get; set; }

        /// <summary>
        /// The Placerank of this element , if applicable.
        /// </summary>
        /// 
        [JsonPropertyName("place_rank")]
        public int PlaceRank { get; set; }


    }
}
