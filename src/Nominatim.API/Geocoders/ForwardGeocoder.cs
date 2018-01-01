using System.Collections.Generic;
using Nominatim.API.Extensions;
using Nominatim.API.Models;
using Nominatim.API.Web;

namespace Nominatim.API.Geocoders {
    public class ForwardGeocoder : GeocoderBase {

        public ForwardGeocodeResponse[] Geocode(ForwardGeocodeRequest req) {
            return WebInterface.GetRequest<ForwardGeocodeResponse[]>(url, buildQueryString(req)).Result;
        }

        protected override Dictionary<string, string> buildQueryString(ForwardGeocodeRequest r) {
            var c = new Dictionary<string, string>();

            // We only support JSON
            c.AddStringIfHasValue("format", format);
            c.AddStringIfHasValue("key", key);
            
            if (r.queryString.hasValue()) {
                c.Add("q", r.queryString);
            }
            else {
                c.AddStringIfHasValue("street", r.StreetAddress);
                c.AddStringIfHasValue("city", r.City);
                c.AddStringIfHasValue("county", r.County);
                c.AddStringIfHasValue("state", r.State);
                c.AddStringIfHasValue("country", r.Country);
                c.AddStringIfHasValue("postalcode", r.PostalCode);
            }

            if (r.ViewBox != null) {
                var v = r.ViewBox.Value;
                c.Add("viewbox", $"{v.minLatitude},{v.minLongitude},{v.maxLatitude},{v.maxLongitude}");
            }
            
            c.AddBoolIfSet("bounded", r.ViewboxBoundedResults);
            c.AddBoolIfSet("addressdetails", r.BreakdownAddressElements);
            c.AddIntIfSet("limit", r.LimitResults);
            c.AddStringIfHasValue("accept-language", r.PreferredLanguages);
            c.AddStringIfHasValue("countrycodes", r.CountryCodeSearch);
            c.AddBoolIfSet("namedetails", r.ShowAlternativeNames);
            c.AddBoolIfSet("dedupe", r.DedupeResults);

            c.AddBoolIfSet("polygon_geojson", r.ShowGeoJSON);
            c.AddBoolIfSet("polygon_kml", r.ShowKML);
            c.AddBoolIfSet("polygon_svg", r.ShowSVG);
            c.AddBoolIfSet("polygon_text", r.ShowPolygonText);
            c.AddBoolIfSet("extratags", r.ShowExtraTags);

            return c;
        }
    }
}