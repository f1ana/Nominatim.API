using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Nominatim.API.Contracts;

namespace Nominatim.API.Web {
    public static class WebInterface {
        private static readonly HttpClient _httpClient = new HttpClient();

        public static async Task<T> GetRequest<T>(string url, Dictionary<string, string> parameters) {
            var req = QueryHelpers.AddQueryString(url, parameters);

            var result = await _httpClient.GetStringAsync(req);
            var settings = new JsonSerializerSettings {ContractResolver = new PrivateContractResolver()};

            return JsonConvert.DeserializeObject<T>(result, settings);
        }
    }
}