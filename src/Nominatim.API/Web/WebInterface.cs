using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Nominatim.API.Contracts;

namespace Nominatim.API.Web {
    /// <summary>
    ///     Provides a means of sending HTTP requests to a Nominatim server
    /// </summary>
    public static class WebInterface {
        private static readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        ///     Send a request to the Nominatim server
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize response onto</typeparam>
        /// <param name="url">URL of Nominatim server method</param>
        /// <param name="parameters">Query string parameters</param>
        /// <returns>Deserialized instance of T</returns>
        public static async Task<T> GetRequest<T>(string url, Dictionary<string, string> parameters) {
            var req = QueryHelpers.AddQueryString(url, parameters);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            _httpClient.DefaultRequestHeaders.UserAgent.Clear();
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("f1ana.Nominatim.API", Assembly.GetExecutingAssembly().GetName().Version.ToString()));

            var result = await _httpClient.GetStringAsync(req).ConfigureAwait(false);
            var settings = new JsonSerializerSettings {ContractResolver = new PrivateContractResolver()};

            return JsonConvert.DeserializeObject<T>(result, settings);
        }
    }
}
