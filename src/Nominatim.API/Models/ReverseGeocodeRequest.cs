namespace Nominatim.API.Models {
    public class ReverseGeocodeRequest : BaseNominatimRequest {
        /// <summary>
        ///     Latitude of the location to generate an address for.
        /// </summary>
        public double? Latitude { get; set; }

        /// <summary>
        ///     Longitude of the location to generate an address for.
        /// </summary>
        public double? Longitude { get; set; }

        /// <summary>
        ///     Level of detail required where 0 is country and 18 is house/building. Defaults to 18. A lower number increases
        ///     speed of the server's response.
        /// </summary>
        public int? ZoomLevel { get; set; }

        /// <summary>
        ///     Limit search to a list of countries
        /// </summary>
        public string CountryCodeSearch { get; set; }

        /// <summary>
        ///     Sometimes you have several objects in OSM identifying the same place or object in reality. The simplest case is a
        ///     street being split in many different OSM ways due to different characteristics.
        ///     Nominatim will attempt to detect such duplicates and only return one match; this is controlled by the dedupe
        ///     parameter which defaults to 1. Since the limit is, for reasons of efficiency, enforced before and not after
        ///     de-duplicating, it is possible that de-duplicating leaves you with less results than requested.
        /// </summary>
        public bool? DedupeResults { get; set; }

        /// <summary>
        ///     Output geometry of results in geojson format.
        /// </summary>
        public bool? ShowGeoJSON { get; set; }

        /// <summary>
        ///     Output geometry of results in kml format.
        /// </summary>
        public bool? ShowKML { get; set; }

        /// <summary>
        ///     Output geometry of results in svg format.
        /// </summary>
        public bool? ShowSVG { get; set; }

        /// <summary>
        ///     Output geometry of results as a WKT.
        /// </summary>
        public bool? ShowPolygonText { get; set; }
    }
}