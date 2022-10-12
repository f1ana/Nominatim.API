using Microsoft.Extensions.DependencyInjection;
using Nominatim.API.Address;
using Nominatim.API.Geocoders;
using Nominatim.API.Interfaces;
using Nominatim.API.Web;
using System.Net.Http;

namespace Nominatim.API
{
    public static class StartupSetup
    {
        public const string DefaultBaseUrl = @"https://nominatim.openstreetmap.org";
        /// <summary>
        /// Adds all Nominatim services and allows using through INominatimWebInterface
        /// </summary>
        /// <param name="services"></param>
        /// <param name="baseUrl"></param>
        /// <param name="apiKey"></param>
        public static void AddNoninatimServices(this IServiceCollection services,
            string baseUrl = DefaultBaseUrl,
            string apiKey = null)
        {
            services.AddScoped<INominatimWebInterface, NominatimWebInterface>(s
                 => new NominatimWebInterface(s.GetRequiredService<IHttpClientFactory>(), s, baseUrl, apiKey));
            services.AddScoped<IAddressSearcher, AddressSearcher>();
            services.AddScoped<IReverseGeocoder, ReverseGeocoder>();
            services.AddScoped<IForwardGeocoder, ForwardGeocoder>();
        }
    }
}
