using System.Collections.Generic;
using Nominatim.API.Models;

namespace Nominatim.API {
    public abstract class GeocoderBase {
        public string url = string.Empty;
        public string key = string.Empty;
        public string format = "json";

        protected abstract Dictionary<string, string> buildQueryString(ForwardGeocodeRequest r);
    }
}