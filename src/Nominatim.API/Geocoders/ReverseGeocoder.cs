
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Nominatim.API.Extensions;
using Nominatim.API.Interfaces;
using Nominatim.API.Models;
using Nominatim.API.Web;

namespace Nominatim.API.Geocoders {
    /// <summary>
    ///     Class to enable reverse geocoding (e.g. latitude and longitude to address)
    /// </summary>
    public class ReverseGeocoder : GeocoderBase, IReverseGeocoder {
        private readonly INominatimWebInterface _nominatimWebInterface;
        
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="nominatimWebInterface">Injected instance of INominatimWebInterface</param>
        /// <param name="URL">URL to Nominatim service.  Defaults to OSM demo site.</param>
        public ReverseGeocoder(INominatimWebInterface nominatimWebInterface, string URL = null) : base(URL ?? @"https://nominatim.openstreetmap.org/reverse") {
            _nominatimWebInterface = nominatimWebInterface;
        }

        /// <summary>
        ///     Attempt to get an address or location from a set of coordinates
        /// </summary>
        /// <param name="req">Reverse geocode request object</param>
        /// <returns>A single reverse geocode response</returns>
        public async Task<GeocodeResponse> ReverseGeocode(ReverseGeocodeRequest req) {
            var result = await _nominatimWebInterface.GetRequest<GeocodeResponse>(url, buildQueryString(req)).ConfigureAwait(false);
            return result;
        }

        private Dictionary<string, string> buildQueryString(ReverseGeocodeRequest r) {
            var c = new Dictionary<string, string>();

            // We only support JSON
            c.AddIfSet("format", format);
            c.AddIfSet("key", key);

            c.AddIfSet("lat", r.Latitude?.ToString(CultureInfo.InvariantCulture.NumberFormat));
            c.AddIfSet("lon", r.Longitude?.ToString(CultureInfo.InvariantCulture.NumberFormat));
            c.AddIfSet("zoom", r.ZoomLevel);
            c.AddIfSet("addressdetails", r.BreakdownAddressElements);
            c.AddIfSet("namedetails", r.ShowAlternativeNames);
            c.AddIfSet("accept-language", r.PreferredLanguages);
            c.AddIfSet("countrycodes", r.CountryCodeSearch);
            c.AddIfSet("polygon_geojson", r.ShowGeoJSON);
            c.AddIfSet("polygon_kml", r.ShowKML);
            c.AddIfSet("polygon_svg", r.ShowSVG);
            c.AddIfSet("polygon_text", r.ShowPolygonText);
            c.AddIfSet("extratags", r.ShowExtraTags);

            return c;
        }
    }
}
