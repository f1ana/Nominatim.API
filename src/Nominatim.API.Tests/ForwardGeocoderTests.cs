using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nominatim.API.Geocoders;
using Nominatim.API.Models;

namespace Nominatim.API.Tests {
    [TestClass]
    public class ForwardGeocoderTests {
        [TestMethod]
        public void TestSuccessfulGeocode() {
            var x = new ForwardGeocoder {
                url = @"http://nominatim.openstreetmap.org/search"
            };

            var r = x.Geocode(new ForwardGeocodeRequest {
                queryString = "1600 Pennsylvania Avenue, Washington, DC",

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });

            Assert.IsTrue(r.Length > 0);
        }
    }
}