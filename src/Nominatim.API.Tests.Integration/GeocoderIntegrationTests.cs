using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Nominatim.API.Geocoders;
using Nominatim.API.Models;
using Nominatim.API.Web;
using NUnit.Framework;

namespace Nominatim.API.Tests
{
    public class GeocoderIntegrationTests {
        private IServiceProvider _serviceProvider;
        
        [SetUp]
        public void Setup() {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddNoninatimServices();
            serviceCollection.AddHttpClient();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        
        [Test]
        public async Task TestSuccessfulForwardGeocode() {
            var forwardGeocoder = _serviceProvider.GetService<INominatimWebInterface>();

            var r = await forwardGeocoder.Geocode(new ForwardGeocodeRequest {
                queryString = "1600 Pennsylvania Avenue, Washington, DC",

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });

            Assert.IsTrue(r.Length > 0);
        }

        [Test]
        public async Task TestSuccessfulReverseGeocodeBuilding() {
            var reverseGeocoder = _serviceProvider.GetService<INominatimWebInterface>();

            var r2 = await reverseGeocoder.ReverseGeocode(new ReverseGeocodeRequest {
                Longitude = -77.0365298,
                Latitude = 38.8976763,

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });
            
            Assert.IsTrue(r2.PlaceID > 0);
        }


        [Test]
        public async Task TestSuccessfulReverseGeocodeRoad() {
            var reverseGeocoder = _serviceProvider.GetService<INominatimWebInterface>();

            var r3 = await reverseGeocoder.ReverseGeocode(new ReverseGeocodeRequest
            {
                Longitude = -58.7051622809683,
                Latitude = -34.440723129053,

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });

            Assert.IsTrue((r3.PlaceID > 0) && (r3.Category == "highway") && (r3.ClassType == "milestone"));
        }
    }
}