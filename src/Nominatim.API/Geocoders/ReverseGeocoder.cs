using System.Collections.Generic;
using Nominatim.API.Models;

namespace Nominatim.API.Geocoders {
    public class ReverseGeocoder : GeocoderBase {
        protected override Dictionary<string, string> buildQueryString(ForwardGeocodeRequest r) {
            throw new System.NotImplementedException();
        }
    }
}