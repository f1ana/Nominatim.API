using Nominatim.API.Models;

namespace Nominatim.API.Geocoders
{
    public abstract class GeocoderBase: BaseUrlService
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="nominatim">Injected instance of INominatimWebInterface</param>
        protected GeocoderBase(INominatimWebInterface nominatim) : base(nominatim) { }
        /// <summary>
        /// API Key, if you are using an Nominatim service that requires one.
        /// </summary>
        public string Key => NominatimWeb.ApiKey;
        /// <summary>
        /// Format of response objects.  This library only supports JSON/JSONV2.
        /// </summary>
        public readonly string format = "jsonv2";
    }
}