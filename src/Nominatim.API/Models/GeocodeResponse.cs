using GeoJSON.Net.Converters;
using Newtonsoft.Json;

namespace Nominatim.API.Models {
    public class GeocodeResponse : BaseNominatimResponse {
        [JsonProperty("boundingbox")]
        private double[] bbox { get; set; }

        /// <summary>
        ///     Bounding box coordinates where this element is located.
        /// </summary>
        public BoundingBox? BoundingBox {
            get {
                if (bbox == null || bbox.Length != 4) {
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

        /// <summary>
        ///     Output geometry of results in geojson format. Returned when polygon_geojson=1 is set in the request.
        /// </summary>
        [JsonProperty("geojson")]
        [JsonConverter(typeof(GeoJsonConverter))]
        public object GeoJSON { get; set; }


        /// <summary>
        ///     Output geometry of results in kml format. Returned when polygon_kml=1 is set in the request.
        /// </summary>
        [JsonProperty("geokml")]
        public string GeoKML { get; set; }

        /// <summary>
        ///     Output geometry of results in svg format. Returned when polygon_svg=1 is set in the request.
        /// </summary>
        [JsonProperty("svg")]
        public string GeoSVG { get; set; }

        /// <summary>
        ///     Output geometry of results as a WKT. Returned when polygon_text=1 is set in the request.
        /// </summary>
        [JsonProperty("geotext")]
        public string GeoText { get; set; }
    }
}