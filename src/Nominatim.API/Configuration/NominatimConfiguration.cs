using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nominatim.API.Address;
using Nominatim.API.Geocoders;
using Nominatim.API.Interfaces;

namespace Nominatim.API.Configuration
{
    /// <inheritdoc/>
    internal class NominatimConfiguration : INominatimConfiguration
    {
        private readonly IServiceCollection serviceCollection;

        public NominatimConfiguration(IServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection;
        }

        /// <inheritdoc/>
        public INominatimConfiguration WithAddressSearch()
        {
            serviceCollection.TryAddTransient<IAddressSearcher, AddressSearcher>();
            return this;
        }

        /// <inheritdoc/>
        public INominatimConfiguration WithForwardGeocoder()
        {
            serviceCollection.TryAddTransient<IForwardGeocoder, ForwardGeocoder>();
            return this;
        }

        /// <inheritdoc/>
        public INominatimConfiguration WithReverseGeocoder()
        {
            serviceCollection.TryAddTransient<IReverseGeocoder, ReverseGeocoder>();
            return this;
        }

        /// <inheritdoc/>
        public INominatimConfiguration WithAllGeocoders()
        {
            return this.WithAddressSearch().WithForwardGeocoder().WithReverseGeocoder();
        }
    }
}
