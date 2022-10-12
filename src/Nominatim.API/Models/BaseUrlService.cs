namespace Nominatim.API.Models
{
    /// <summary>
    /// Base class for all Nominatim services with Url-request
    /// </summary>
    public abstract class BaseUrlService
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="nominatim">Injected instance of INominatimWebInterface</param>
        protected BaseUrlService(INominatimWebInterface nominatimWeb)
        {
            NominatimWeb = nominatimWeb;
        }
        /// <summary>
        /// Main Nominatim service
        /// </summary>
        protected INominatimWebInterface NominatimWeb { get; set; }
        /// <summary>
        /// API name for request
        /// </summary>
        protected abstract string ApiMethod { get; }
        /// <summary>
        /// Get full Url for request
        /// </summary>
        /// <returns></returns>
        protected string GetRequestUrl()
            => $"{NominatimWeb.BaseUrl}/{ApiMethod}";
    }
}
