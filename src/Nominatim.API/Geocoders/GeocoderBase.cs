namespace Nominatim.API.Geocoders {
    public abstract class GeocoderBase {
        /// <summary>
        /// URL to Nominatim service
        /// </summary>
        public string url = string.Empty;
        /// <summary>
        /// API Key, if you are using an Nominatim service that requires one.
        /// </summary>
        public string key = string.Empty;
        /// <summary>
        /// Format of response objects.  This library only supports JSON.
        /// </summary>
        public readonly string format = "json";
    }
}