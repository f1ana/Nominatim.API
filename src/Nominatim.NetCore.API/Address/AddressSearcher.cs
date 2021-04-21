using System.Collections.Generic;
using System.Threading.Tasks;
using Nominatim.NetCore.API.Extensions;
using Nominatim.NetCore.API.Models;
using Nominatim.NetCore.API.Web;

namespace Nominatim.NetCore.API.Address {
    /// <summary>
    /// Lookup the address of one or multiple OSM objects like node, way or relation.
    /// </summary>
    public class AddressSearcher {
        public string url;
        public string applicationName;
        //jsonv2 not supported for lookup
        private readonly string format = "json";
        /// <summary>
        /// API Key, if you are using an Nominatim service that requires one.
        /// </summary>
        public string key;

        /// <summary>
        /// Constructur
        /// </summary>
        /// <param name="URL">URL to Nominatim service.  Defaults to OSM demo site.</param>
        public AddressSearcher(string URL = null, string ApplicationName = null) {
            url = URL ?? @"https://nominatim.openstreetmap.org/lookup";
            applicationName = ApplicationName;
        }

        /// <summary>
        /// Lookup the address of one or multiple OSM objects like node, way or relation.
        /// </summary>
        /// <param name="req">Search request object</param>
        /// <returns>Array of lookup reponses</returns>
        public async Task<AddressLookupResponse[]> Lookup(AddressSearchRequest req) {
            var result = await WebInterface.GetRequest<AddressLookupResponse[]>(url: this.url, parameters: buildQueryString(req), applicationName: this.applicationName).ConfigureAwait(false);
            return result;
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