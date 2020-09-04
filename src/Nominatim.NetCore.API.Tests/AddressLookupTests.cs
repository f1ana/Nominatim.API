using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Nominatim.NetCore.API.Address;
using Nominatim.NetCore.API.Models;


namespace Nominatim.NetCore.API.Tests
{
    [TestClass]
    public class AddressLookupTests
    {
        [TestMethod]
        public void TestSuccessfulAddressLookup()
        {
            var x = new AddressSearcher(ApplicationName: "upnorthspace");
            var r = x.Lookup(new AddressSearchRequest
            {
                OSMIDs = new List<string>(new[] { "R146656", "W104393803", "N240109189" }),
                BreakdownAddressElements = true,
                ShowAlternativeNames = true,
                ShowExtraTags = true
            });
            r.Wait();

            Assert.IsTrue(r.Result.Length > 0);
        }
    }
}
