using System.Threading.Tasks;
using Nominatim.API.Models;

namespace Nominatim.API.Interfaces {
    public interface IQuerySearcher {
        Task<AddressSearchResponse[]> Search(SearchQueryRequest req);
    }
}