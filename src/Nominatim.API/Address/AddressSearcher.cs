using System.Collections.Generic;
using Nominatim.API.Extensions;
using Nominatim.API.Models;
using Nominatim.API.Web;

namespace Nominatim.API.Address {
    /// <summary>
    /// Lookup the address of one or multiple OSM objects like node, way or relation.
    /// </summary>
    public class AddressSearcher {
        public string url;
        private readonly string format = "json";
        /// <summary>
        /// API Key, if you are using an Nominatim service that requires one.
        /// </summary>
        public string key;

        /// <summary>
        /// Constructur
        /// </summary>
        /// <param name="URL">URL to Nominatim service.  Defaults to OSM demo site.</param>
        public AddressSearcher(string URL = null) {
            url = URL ?? @"http://nominatim.openstreetmap.org/lookup";
        }

        /// <summary>
        /// Lookup the address of one or multiple OSM objects like node, way or relation.
        /// </summary>
        /// <param name="req">Search request object</param>
        /// <returns>Array of lookup reponses</returns>
        public AddressLookupResponse[] Lookup(AddressSearchRequest req) {
            return WebInterface.GetRequest<AddressLookupResponse[]>(url, buildQueryString(req)).Result;
        }

        private Dictionary<string, string> buildQueryString(AddressSearchRequest r) {
            var c = new Dictionary<string, string>();

            c.AddIfSet("format", format);
            c.AddIfSet("key", key);
            c.AddIfSet("accept-language", r.PreferredLanguages);
            c.AddIfSet("addressdetails", r.BreakdownAddressElements);
            c.AddIfSet("namedetails", r.ShowAlternativeNames);
            c.AddIfSet("extratags", r.ShowExtraTags);
            c.AddIfSet("email", r.EmailAddress);
            c.AddIfSet("osm_ids", string.Join(",", r.OSMIDs ?? new List<string>()));

            return c;
        }
    }
}