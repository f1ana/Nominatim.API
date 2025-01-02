using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nominatim.API.Extensions;
using Nominatim.API.Interfaces;
using Nominatim.API.Models;

namespace Nominatim.API.Geocoders {
    /// <summary>
    ///     Class to enable forward geocoding (e.g.  address to latitude and longitude)
    /// </summary>
    public class ForwardGeocoder : GeocoderBase, IForwardGeocoder {

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="nominatimWebInterface">Injected instance of INominatimWebInterface</param>
        /// <param name="URL">URL to Nominatim service.  Defaults to OSM demo site.</param>
        /// <param name="apiKey">API Key, if you are using an Nominatim service that requires one.</param>
        public ForwardGeocoder(
            INominatimWebInterface nominatimWebInterface,
            string URL = @"https://nominatim.openstreetmap.org/search",
            string apiKey = "") : base(nominatimWebInterface, URL, apiKey) { }

        /// <summary>
        ///     Attempt to get coordinates for a specified query or address.
        /// </summary>
        /// <param name="req">Geocode request object</param>
        /// <returns>Array of geocode responses</returns>
        public async Task<GeocodeResponse[]> Geocode(ForwardGeocodeRequest req) {
            var result = await _nominatimWebInterface.GetRequest<GeocodeResponse[]>(url, buildQueryString(req)).ConfigureAwait(false);
            return result;
        }

        private Dictionary<string, string> buildQueryString(ForwardGeocodeRequest r) {
            var c = new Dictionary<string, string>();

            // We only support JSON
            c.AddIfSet("format", format);
            c.AddIfSet("key", key);

            if (r.queryString.hasValue()) {
                c.Add("q", r.queryString);
            }
            else {
                c.AddIfSet("street", r.StreetAddress);
                c.AddIfSet("city", r.City);
                c.AddIfSet("county", r.County);
                c.AddIfSet("state", r.State);
                c.AddIfSet("country", r.Country);
                c.AddIfSet("postalcode", r.PostalCode);
            }

            if (r.ViewBox != null) {
                var v = r.ViewBox.Value;
                c.Add("viewbox", $"{v.minLongitude},{v.minLatitude},{v.maxLongitude},{v.maxLatitude}");
            }

            c.AddIfSet("bounded", r.ViewboxBoundedResults);
            c.AddIfSet("addressdetails", r.BreakdownAddressElements);
            c.AddIfSet("limit", r.LimitResults);
            c.AddIfSet("accept-language", r.PreferredLanguages);
            c.AddIfSet("countrycodes", r.CountryCodeSearch);
            c.AddIfSet("namedetails", r.ShowAlternativeNames);
            c.AddIfSet("dedupe", r.DedupeResults);

            c.AddIfSet("polygon_geojson", r.ShowGeoJSON);
            c.AddIfSet("polygon_kml", r.ShowKML);
            c.AddIfSet("polygon_svg", r.ShowSVG);
            c.AddIfSet("polygon_text", r.ShowPolygonText);
            c.AddIfSet("extratags", r.ShowExtraTags);

            c.AddIfSet("exclude_place_ids", (r.ExcludeIds?.Any() ?? false) ? string.Join(",", r.ExcludeIds.Select(x => x.ToString())) : null);

            return c;
        }
    }
}