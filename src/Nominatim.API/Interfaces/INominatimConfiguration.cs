namespace Nominatim.API.Interfaces
{
    /// <summary>
    /// Configure the Nominatim DI registration
    /// </summary>
    public interface INominatimConfiguration
    {
        /// <summary>
        /// Add the <see cref="IAddressSearcher"/> to your services
        /// </summary>
        /// <returns>The same <see cref="INominatimConfiguration"/> instance to chain your configuration</returns>
        INominatimConfiguration WithAddressSearch();

        /// <summary>
        /// Add the <see cref="IReverseGeocoder"/> to your services
        /// </summary>
        /// <returns>The same <see cref="INominatimConfiguration"/> instance to chain your configuration</returns>
        INominatimConfiguration WithReverseGeocoder();

        /// <summary>
        /// Add the <see cref="IForwardGeocoder"/> to your services
        /// </summary>
        /// <returns>The same <see cref="INominatimConfiguration"/> instance to chain your configuration</returns>
        INominatimConfiguration WithForwardGeocoder();

        /// <summary>
        /// A shortcut to add all geocoders
        /// </summary>
        /// <returns>The same <see cref="INominatimConfiguration"/> instance to chain your configuration</returns>
        INominatimConfiguration WithAllGeocoders();


    }
}
