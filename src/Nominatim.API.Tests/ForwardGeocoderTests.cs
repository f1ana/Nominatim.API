using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nominatim.API.Geocoders;
using Nominatim.API.Models;

namespace Nominatim.API.Tests {
    [TestClass]
    public class GeocoderTests {
        [TestMethod]
        public void TestSuccessfulForwardGeocode() {
            var x = new ForwardGeocoder();

            var r = x.Geocode(new ForwardGeocodeRequest {
                queryString = "1600 Pennsylvania Avenue, Washington, DC",

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });

            Assert.IsTrue(r.Length > 0);
        }

        [TestMethod]
        public void TestSuccessfulReverseGeocode() {
            var y = new ReverseGeocoder();

            var r2 = y.ReverseGeocode(new ReverseGeocodeRequest {
                Longitude = -77.0365298,
                Latitude = 38.8976763,

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });

            Assert.IsTrue(r2.PlaceID > 0);
        }
    }
}