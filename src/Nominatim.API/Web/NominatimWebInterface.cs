using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nominatim.API.Contracts;
using Nominatim.API.Interfaces;

namespace Nominatim.API.Web {
    /// <summary>
    ///     Provides a means of sending HTTP requests to a Nominatim server
    /// </summary>
    public class NominatimWebInterface : INominatimWebInterface {
        private static readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new PrivateContractResolver()
        };

        private static readonly string _version = Assembly.GetExecutingAssembly().GetName().Version.ToString();


        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _httpClientName;
        private readonly string _productName;

        private readonly ProductInfoHeaderValue _productInfoHeaderValue;

        public NominatimWebInterface(
            IHttpClientFactory httpClientFactory,
            string httpClientName = "DefaultNominatimWebInterfaceHttpClient",
            string productName = "f1ana.Nominatim.API") {
            _httpClientFactory = httpClientFactory;
            _httpClientName = httpClientName;
            _productName = productName;

            _productInfoHeaderValue = new ProductInfoHeaderValue(_productName, _version);
        }
        
        /// <summary>
        ///     Send a request to the Nominatim server
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize response onto</typeparam>
        /// <param name="url">URL of Nominatim server method</param>
        /// <param name="parameters">Query string parameters</param>
        /// <returns>Deserialized instance of T</returns>
        public async Task<T> GetRequest<T>(string url, Dictionary<string, string> parameters) {
            var req = addQueryStringToUrl(url, parameters);

            using (var httpClient = _httpClientFactory.CreateClient(_httpClientName))
            {
                AddUserAgent(httpClient);
                var result = await httpClient.GetStringAsync(req).ConfigureAwait(false);

                return JsonConvert.DeserializeObject<T>(result, _jsonSerializerSettings);
            }
        }

        private static string addQueryStringToUrl(string url, IDictionary<string, string> parameters) {
            if ((parameters?.Keys.Count ?? 0) == 0) {
                return url;
            }

            var op = url.IndexOf('?') != -1 ? '&' : '?';
            var sb = new StringBuilder();
            sb.Append(url);
            foreach (var kvp in parameters) {
                sb.Append(op);
                sb.Append($"{UrlEncoder.Default.Encode(kvp.Key)}={UrlEncoder.Default.Encode(kvp.Value)}");
                op = '&';
            }

            return sb.ToString();
        }

        private void AddUserAgent(HttpClient httpClient) {
            httpClient.DefaultRequestHeaders.UserAgent.Clear();
            httpClient.DefaultRequestHeaders.UserAgent.Add(_productInfoHeaderValue);
        }
    }
}