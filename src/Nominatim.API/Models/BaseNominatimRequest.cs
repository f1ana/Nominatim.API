namespace Nominatim.API.Models {
    public class BaseNominatimRequest {
        /// <summary>
        /// Include a breakdown of the address into elements
        /// </summary>
        public bool? BreakdownAddressElements { get; set; }
        /// <summary>
        /// Preferred language order for showing search results, overrides the value specified in the "Accept-Language" HTTP header.
        /// Either uses standard rfc2616 accept-language string or a simple comma separated list of language codes.
        /// </summary>
        public string PreferredLanguages { get; set; }
        /// <summary>
        /// Include additional information in the result if available, e.g. wikipedia link, opening hours.
        /// </summary>
        public bool? ShowExtraTags { get; set; }
        /// <summary>
        /// Include a list of alternative names in the results.
        /// These may include language variants, references, operator and brand.
        /// </summary>
        public bool? ShowAlternativeNames { get; set; }
    }
}