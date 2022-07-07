using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nominatim.API.Interfaces {
    public interface INominatimWebInterface {
        Task<T> GetRequest<T>(string url, Dictionary<string, string> parameters);
    }
}