using System.Threading.Tasks;
using Nominatim.API.Models;

namespace Nominatim.API.Interfaces {
    public interface IReverseGeocoder {
        Task<GeocodeResponse> ReverseGeocode(ReverseGeocodeRequest req);
    }
}