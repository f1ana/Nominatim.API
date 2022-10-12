using System.Threading.Tasks;
using Nominatim.API.Models;

namespace Nominatim.API.Interfaces {
    public interface IForwardGeocoder {
        /// <summary>
        ///     Attempt to get coordinates for a specified query or address.
        /// </summary>
        /// <param name="req">Geocode request object</param>
        /// <returns>Array of geocode responses</returns>
        Task<GeocodeResponse[]> Geocode(ForwardGeocodeRequest req);
    }
}