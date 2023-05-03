using Nominatim.API.Interfaces;

namespace Nominatim.API.Geocoders {
    public abstract class GeocoderBase {
        protected GeocoderBase(INominatimWebInterface nominatimWebInterface, string URL, string apiKey = "") {
            _nominatimWebInterface = nominatimWebInterface;
            url = URL;
            key = apiKey;
        }

        protected readonly INominatimWebInterface _nominatimWebInterface;

        /// <summary>
        /// URL to Nominatim service
        /// </summary>
        public string url;
        /// <summary>
        /// API Key, if you are using an Nominatim service that requires one.
        /// </summary>
        public string key;
        /// <summary>
        /// Format of response objects.  This library only supports JSON/JSONV2.
        /// </summary>
        public const string format = "jsonv2";
    }
}