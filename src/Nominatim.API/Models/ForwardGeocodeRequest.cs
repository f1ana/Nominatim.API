namespace Nominatim.API.Models {
    public class ForwardGeocodeRequest : BaseNominatimRequest {
        /// <summary>
        ///     Query string to search for.  Do not combine with any address fields.
        /// </summary>
        public string queryString { get; set; }

        /// <summary>
        ///     Street address to search for.  Do not combine with query string.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        ///     City to search for.  Do not combine with query string.
        /// </summary
        public string City { get; set; }

        /// <summary>
        ///     County to search for.  Do not combine with query string.
        /// </summary>
        public string County { get; set; }

        /// <summary>
        ///     State to search for.  Do not combine with query string.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Country to search for.  Do not combine with query string.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Postalcode to search for.  Do not combine with query string.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        ///     The preferred area to find search results. Any two corner points of the box are accepted in any order as long as
        ///     they span a real box.
        /// </summary>
        public BoundingBox? ViewBox { get; set; }

        /// <summary>
        ///     Restrict the results to only items contained with the viewbox
        /// </summary>
        public bool? ViewboxBoundedResults { get; set; }

        /// <summary>
        ///     Limit the number of returned results. Default is 10.
        /// </summary>
        public int? LimitResults { get; set; }

        /// <summary>
        ///     Limit search results to a specific country (or a list of countries).
        ///     countrycode should be the ISO 3166-1alpha2 code, e.g.gb for the United Kingdom, de for Germany, etc.
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