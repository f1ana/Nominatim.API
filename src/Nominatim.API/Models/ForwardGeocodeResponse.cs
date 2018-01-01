using System.Collections.Generic;
using GeoJSON.Net;
using GeoJSON.Net.Converters;
using GeoJSON.Net.Geometry;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Nominatim.API.Models {
    public class ForwardGeocodeResponse {
        [JsonProperty("place_id")]
        public int PlaceID { get; set; }
        [JsonProperty("licence")]
        public string License { get; set; }
        [JsonProperty("osm_type")]
        public string OSMType { get; set; }
        [JsonProperty("osm_id")]
        public int OSMID { get; set; }
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lon")]
        public double Longitude { get; set; }
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
        [JsonProperty("boundingbox")]
        private double[] bbox { get; set; }

        public BoundingBox? BoundingBox {
            get {
                if (bbox == null || bbox?.Length != 4) {
                    return null;
                }
                return new BoundingBox {
                    minLatitude = bbox[0],
                    maxLatitude = bbox[1],
                    minLongitude = bbox[2],
                    maxLongitude = bbox[3]
                };
            }
        }

        [JsonProperty("class")]
        public string Class { get; set; }
        [JsonProperty("type")]
        public string ClassType { get; set; }
        [JsonProperty("importance")]
        public double Importance { get; set; }
        [JsonProperty("icon")]
        public string IconURL { get; set; }

        [JsonProperty("address")]
        public AddressResult Address { get; set; }
        [JsonProperty("extratags")]
        public IDictionary<string, string> ExtraTags { get; set; }
        [JsonProperty("namedetails")]
        public IDictionary<string, string> AlternateNames { get; set; }
        [JsonProperty("geojson")]
        [JsonConverter(typeof(GeoJsonConverter))]
        private object GeoJSON { get; set; }
        

        [JsonProperty("geokml")]
        public string GeoKML { get; set; }
        [JsonProperty("svg")]
        public string GeoSVG { get; set; }
        [JsonProperty("geotext")]
        public string GeoText { get; set; }
    }
}