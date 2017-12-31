using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nominatim.API.Models;

namespace Nominatim.API.Tests
{
    [TestClass]
    public class ForwardGeocoderTests
    {
        [TestMethod]
        public void TestSuccessfulGeocode() {
            var x = new ForwardGeocoder() {
                key = "",
                url = @"https://locationiq.org/v1/search.php"
            };

            var r = x.Geocode(new ForwardGeocodeRequest {
                queryString = ""
            });

            Assert.IsTrue(r.Length > 0);
        }
    }
}
