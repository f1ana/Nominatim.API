using System.Collections.Generic;
using System.Collections.Specialized;
using Nominatim.API.Models;

namespace Nominatim.API {
    public class ReverseGeocoder : GeocoderBase {
        protected override Dictionary<string, string> buildQueryString(ForwardGeocodeRequest r) {
            throw new System.NotImplementedException();
        }
    }
}