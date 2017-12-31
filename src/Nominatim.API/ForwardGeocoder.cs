using System.Collections.Generic;
using System.Collections.Specialized;
using Nominatim.API.Models;
using Nominatim.API.Web;

namespace Nominatim.API {
    public class ForwardGeocoder : GeocoderBase {

        public ForwardGeocodeResponse[] Geocode(ForwardGeocodeRequest req) {
            return WebInterface.GetRequest<ForwardGeocodeResponse[]>(url, buildQueryString(req)).Result;
        }

        protected override Dictionary<string, string> buildQueryString(ForwardGeocodeRequest r) {
            var c = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(format)) {
                c.Add("format", format);
            }

            if (!string.IsNullOrEmpty(key)) {
                c.Add("key", key);
            }

            if (!string.IsNullOrEmpty(r.queryString)) {
                c.Add("q", r.queryString);
            }

            return c;
        }
    }
}