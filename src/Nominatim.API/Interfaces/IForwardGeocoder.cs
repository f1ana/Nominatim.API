using System.Threading.Tasks;
using Nominatim.API.Models;

namespace Nominatim.API.Interfaces {
    public interface IForwardGeocoder {
        Task<GeocodeResponse[]> Geocode(ForwardGeocodeRequest req);
    }
}