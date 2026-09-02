using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nominatim.API.Configuration;
using Nominatim.API.Interfaces;
using Nominatim.API.Web;

namespace Nominatim.API.Extensions
{
    /// <summary>
    /// Extensions for dependency injection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add the base Nominatim service
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> from your DI</param>
        /// <returns>A <see cref="INominatimConfiguration"/> instance to register your desired services</returns>
        public static INominatimConfiguration AddNominatim(this IServiceCollection services)
        {
            services.TryAddTransient<INominatimWebInterface, NominatimWebInterface>();
            return new NominatimConfiguration(services);
        }
    }
}
