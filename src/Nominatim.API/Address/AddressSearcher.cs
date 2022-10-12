using System.Collections.Generic;
using System.Threading.Tasks;
using Nominatim.API.Extensions;
using Nominatim.API.Interfaces;
using Nominatim.API.Models;

namespace Nominatim.API.Address
{
    /// <summary>
    /// Lookup the address of one or multiple OSM objects like node, way or relation.
    /// </summary>
    public class AddressSearcher : BaseUrlService, IAddressSearcher {
        
        //jsonv2 not supported for lookup
        private readonly string format = "json";

        public string Key => NominatimWeb.ApiKey;

        protected override string ApiMethod => "lookup";

        /// <summary>
        /// Constructur
        /// </summary>
        /// <param name="nominatimWebInterface">Injected instance of INominatimWebInterface</param>
        public AddressSearcher(INominatimWebInterface nominatimWebInterface) : base(nominatimWebInterface) { }        

        /// <summary>
        /// Lookup the address of one or multiple OSM objects like node, way or relation.
        /// </summary>
        /// <param name="req">Search request object</param>
        /// <returns>Array of lookup reponses</returns>
        public async Task<AddressLookupResponse[]> Lookup(AddressSearchRequest req) {
            var result = await NominatimWeb.GetRequest<AddressLookupResponse[]>(GetRequestUrl(), buildQueryString(req)).ConfigureAwait(false);
            return result;
        }

        private Dictionary<string, string> buildQueryString(AddressSearchRequest r) {
            var c = new Dictionary<string, string>();

            c.AddIfSet("format", format);
            c.AddIfSet("key", Key);
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