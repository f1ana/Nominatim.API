using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Nominatim.API.Geocoders;
using Nominatim.API.Interfaces;
using Nominatim.API.Models;
using Nominatim.API.Web;
using NUnit.Framework;

namespace Nominatim.API.Tests {
    public class GeocoderIntegrationTests {
        private IServiceProvider _serviceProvider;
        
        [SetUp]
        public void Setup() {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<INominatimWebInterface, NominatimWebInterface>();
            serviceCollection.AddScoped<ForwardGeocoder>();
            serviceCollection.AddScoped<ReverseGeocoder>();
            serviceCollection.AddHttpClient();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        
        [Test]
        public async Task TestSuccessfulForwardGeocode() {
            var forwardGeocoder = _serviceProvider.GetService<ForwardGeocoder>();

            var r = await forwardGeocoder.Geocode(new ForwardGeocodeRequest {
                queryString = "1600 Pennsylvania Avenue, Washington, DC",

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });

            Assert.IsTrue(r.Length > 0 && r[0].OSMID == 238241022);
        }

        [Test]
        public async Task TestSuccessfulForwardGeocode_ExcludedIds()
        {
            var forwardGeocoder = _serviceProvider.GetService<ForwardGeocoder>();

            var r = await forwardGeocoder.Geocode(new ForwardGeocodeRequest
            {
                queryString = "1600 Pennsylvania Avenue, Washington, DC",

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true,
                ExcludeIds = new List<long> { 321631063 }
            });

            Assert.IsTrue(r.Length > 0 && r[0].OSMID != 238241022);
        }


        [Test]
        public async Task TestSuccessfulReverseGeocodeBuilding() {
            var reverseGeocoder = _serviceProvider.GetService<ReverseGeocoder>();

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
            var reverseGeocoder = _serviceProvider.GetService<ReverseGeocoder>();

            var r3 = await reverseGeocoder.ReverseGeocode(new ReverseGeocodeRequest
            {
                Longitude = -58.7051622809683,
                Latitude = -34.440723129053,

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });

            Assert.IsTrue((r3.PlaceID > 0) && (r3.Category == "highway") && (r3.ClassType == "motorway"));
        }
    }
}