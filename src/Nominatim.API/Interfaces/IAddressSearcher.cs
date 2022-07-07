using System.Threading.Tasks;
using Nominatim.API.Models;

namespace Nominatim.API.Interfaces {
    public interface IAddressSearcher {
        Task<AddressLookupResponse[]> Lookup(AddressSearchRequest req);
    }
}