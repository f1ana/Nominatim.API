//using GeoJSON.Net.Converters;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Nominatim.NetCore.API.JsonConverters;

namespace Nominatim.NetCore.API.Models {
    public class GeocodeResponse : BaseNominatimResponse {
        [JsonPropertyName("boundingbox")]
//        [JsonConverter(typeof(InfoToDoubleConverter))]
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
        [JsonPropertyName("geojson")]
        //[JsonConverter(typeof(GeoJsonConverter))]
        [Obsolete(message: "GeoJSON is not yet implemented for .Net Core.", error: true)]
        private object GeoJSON { get; set; }


        /// <summary>
        ///     Output geometry of results in kml format. Returned when polygon_kml=1 is set in the request.
        /// </summary>
        [JsonPropertyName("geokml")]
        public string GeoKML { get; set; }

        /// <summary>
        ///     Output geometry of results in svg format. Returned when polygon_svg=1 is set in the request.
        /// </summary>
        [JsonPropertyName("svg")]
        public string GeoSVG { get; set; }

        /// <summary>
        ///     Output geometry of results as a WKT. Returned when polygon_text=1 is set in the request.
        /// </summary>
        [JsonPropertyName("geotext")]
        public string GeoText { get; set; }
    }
}