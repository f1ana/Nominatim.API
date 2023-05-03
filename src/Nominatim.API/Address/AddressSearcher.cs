using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nominatim.API.Extensions;
using Nominatim.API.Interfaces;
using Nominatim.API.Models;

namespace Nominatim.API.Address {
    /// <summary>
    /// Lookup the address of one or multiple OSM objects like node, way or relation.
    /// </summary>
    public class AddressSearcher : IAddressSearcher {
        private readonly INominatimWebInterface _nominatimWebInterface;
        
        public readonly string url;
        /// <summary>
        /// API Key, if you are using an Nominatim service that requires one.
        /// </summary>
        public readonly string key;

        //jsonv2 not supported for lookup
        private readonly string format = "json";

        /// <summary>
        /// Constructur
        /// </summary>
        /// <param name="nominatimWebInterface">Injected instance of INominatimWebInterface</param>
        /// <param name="URL">URL to Nominatim service.  Defaults to OSM demo site.</param>
        /// <param name="apiKey">API Key, if you are using an Nominatim service that requires one.</param>
        public AddressSearcher(INominatimWebInterface nominatimWebInterface, string URL = @"https://nominatim.openstreetmap.org/lookup", string apiKey = null) {
            _nominatimWebInterface = nominatimWebInterface;
            url = URL;
            key = apiKey;
        }

        /// <summary>
        /// Lookup the address of one or multiple OSM objects like node, way or relation.
        /// </summary>
        /// <param name="req">Search request object</param>
        /// <returns>Array of lookup reponses</returns>
        public async Task<AddressLookupResponse[]> Lookup(AddressSearchRequest req) {
            var result = await _nominatimWebInterface.GetRequest<AddressLookupResponse[]>(url, buildQueryString(req)).ConfigureAwait(false);
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
            c.AddIfSet("osm_ids", r.OSMIDs?.Any() == true ? string.Join(",", r.OSMIDs) : null);

            return c;
        }
    }
}