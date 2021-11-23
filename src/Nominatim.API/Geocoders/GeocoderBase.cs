using System.Net.Http;
using Nominatim.API.Web;

namespace Nominatim.API.Geocoders {
    public abstract class GeocoderBase {
        protected GeocoderBase(string URL, HttpMessageHandler handler = null, bool disposeMessageHandler = false) {
            url = URL;

            webInterface = new WebInterface(handler, disposeMessageHandler);
        }
        protected readonly WebInterface webInterface;

        /// <summary>
        /// URL to Nominatim service
        /// </summary>
        public string url;
        /// <summary>
        /// API Key, if you are using an Nominatim service that requires one.
        /// </summary>
        public string key = string.Empty;
        /// <summary>
        /// Format of response objects.  This library only supports JSON/JSONV2.
        /// </summary>
        public readonly string format = "jsonv2";
    }
}