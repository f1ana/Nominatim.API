namespace Nominatim.API.Models {
    public class ForwardGeocodeRequest {
        public string queryString { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public BoundingBox? ViewBox { get; set; }
        public bool? ViewboxBoundedResults { get; set; }
        public bool? BreakdownAddressElements { get; set; }
        public int? LimitResults { get; set; }
        public string PreferredLanguages { get; set; }
        public string CountryCodeSearch { get; set; }
        public bool? ShowAlternativeNames { get; set; }
        public bool? DedupeResults { get; set; }

        public bool? ShowGeoJSON { get; set; }
        public bool? ShowKML { get; set; }
        public bool? ShowSVG { get; set; }
        public bool? ShowPolygonText { get; set; }
        public bool? ShowExtraTags { get; set; }
    }
}