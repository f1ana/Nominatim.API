using Nominatim.API.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nominatim.API
{
    /// <summary>
    /// Main Nominatim service for all requests
    /// </summary>
    public interface INominatimWebInterface : IAddressSearcher, IReverseGeocoder, IForwardGeocoder
    {
        /// <summary>
        /// base URL for Nominatim, by default https://nominatim.openstreetmap.org
        /// </summary>
        string BaseUrl { get; set; }
        /// <summary>
        /// API Key, if you are using an Nominatim service that requires one.
        /// </summary>
        string ApiKey { get; set; }
        Task<T> GetRequest<T>(string url, Dictionary<string, string> parameters);
    }
}