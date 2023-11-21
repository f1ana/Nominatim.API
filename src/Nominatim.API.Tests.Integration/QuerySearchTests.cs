using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Nominatim.API.Address;
using Nominatim.API.Interfaces;
using Nominatim.API.Models;
using Nominatim.API.Web;
using NUnit.Framework;

namespace Nominatim.API.Tests {
    public class QuerySearchTests {
        private IServiceProvider _serviceProvider;
        
        [SetUp]
        public void Setup() {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<INominatimWebInterface, NominatimWebInterface>();
            serviceCollection.AddScoped<QuerySearcher>();
            serviceCollection.AddHttpClient();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        
        [Test]
        public async Task TestSuccessfulAddressLookup() {
            var querySearcher = _serviceProvider.GetService<QuerySearcher>();
            
            var r = await querySearcher.Search(new SearchQueryRequest {
                queryString = "Bennelong Point, Sydney NSW 2000",
                CountryCodeSearch = "AU",
                BreakdownAddressElements = true,
                ShowAlternativeNames = true,
                ShowExtraTags = true
            });

            Assert.IsTrue(r.Length > 0);
        }
    }
}