using System.Collections.Generic;

namespace Nominatim.API.Models {
    public class AddressSearchRequest : BaseNominatimRequest {
        /// <summary>
        /// A list of up to 50 specific osm node, way or relations ids to return the addresses for
        /// </summary>
        public IList<string> OSMIDs { get; set; }
        /// <summary>
        /// If you are making large numbers of request please include a valid email address or alternatively include your email address as part of the User-Agent string.
        /// </summary>
        public string EmailAddress { get; set; }
    }
}