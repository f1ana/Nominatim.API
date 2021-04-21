using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;
using System.Text.Json.Serialization;
using Nominatim.NetCore.API.Contracts;
using Microsoft.AspNetCore.WebUtilities;

namespace Nominatim.NetCore.API.Web {
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
        public static async Task<T> GetRequest<T>(string url, Dictionary<string, string> parameters, string applicationName = "f1ana.Nominatim.NetCore.API") {
            string requestUri = QueryHelpers.AddQueryString(url, parameters);

            _httpClient.DefaultRequestHeaders.UserAgent.Clear();
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(applicationName, Assembly.GetExecutingAssembly().GetName().Version.ToString()));

            string result = await _httpClient.GetStringAsync(requestUri).ConfigureAwait(false);
            JsonSerializerOptions settings = new JsonSerializerOptions {
                // not implemented yet for .Net Core
                // ContractResolver = new PrivateContractResolver() 
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<T>(result, settings);
        }
    }
}