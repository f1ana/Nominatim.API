using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Nominatim.API.Contracts;
using Nominatim.API.Interfaces;
using Nominatim.API.Models;

namespace Nominatim.API.Web
{
    /// <summary>
    ///     Provides a means of sending HTTP requests to a Nominatim server
    /// </summary>
    public class NominatimWebInterface : INominatimWebInterface {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceProvider _serviceProvider;

        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }

        public NominatimWebInterface(IHttpClientFactory httpClientFactory,
            IServiceProvider serviceProvider,
            string baseUrl = StartupSetup.DefaultBaseUrl,
            string apiKey = null)
        {
            _httpClientFactory = httpClientFactory;
            _serviceProvider = serviceProvider;
            BaseUrl = baseUrl;
            ApiKey = apiKey;
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

            var httpClient = _httpClientFactory.CreateClient();
            AddUserAgent(httpClient);
            var result = await httpClient.GetStringAsync(req).ConfigureAwait(false);
            var settings = new JsonSerializerSettings {ContractResolver = new PrivateContractResolver()};

            return JsonConvert.DeserializeObject<T>(result, settings);
        }

        private static string addQueryStringToUrl(string url, IDictionary<string, string> parameters) {
            if ((parameters?.Keys.Count ?? 0) == 0) {
                return url;
            }

            var op = url.IndexOf('?') != -1;
            var sb = new StringBuilder();
            sb.Append(url);
            foreach (var kvp in parameters) {
                sb.Append(op ? '&' : '?');
                sb.Append($"{UrlEncoder.Default.Encode(kvp.Key)}={UrlEncoder.Default.Encode(kvp.Value)}");
                op = true;
            }

            return sb.ToString();
        }

        private static void AddUserAgent(HttpClient httpClient) {
            httpClient.DefaultRequestHeaders.UserAgent.Clear();
            httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("f1ana.Nominatim.API", Assembly.GetExecutingAssembly().GetName().Version.ToString()));
        }

        public Task<AddressLookupResponse[]> Lookup(AddressSearchRequest req)
            => _serviceProvider.GetRequiredService<IAddressSearcher>().Lookup(req);        

        public Task<GeocodeResponse> ReverseGeocode(ReverseGeocodeRequest req)
            => _serviceProvider.GetRequiredService<IReverseGeocoder>().ReverseGeocode(req);

        public Task<GeocodeResponse[]> Geocode(ForwardGeocodeRequest req)
            => _serviceProvider.GetRequiredService<IForwardGeocoder>().Geocode(req);
    }
}