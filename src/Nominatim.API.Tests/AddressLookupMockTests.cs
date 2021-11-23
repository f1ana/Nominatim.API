using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nominatim.API.Address;
using Nominatim.API.Models;

namespace Nominatim.API.Tests
{
    [TestClass]
    public class AddressLookupMockTests
    {
        [TestMethod]
        public void TestSuccessfulAddressLookup()
        {
            const string responseJson = "[{\"place_id\":281979440,\"licence\":\"Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright\",\"osm_type\":\"relation\",\"osm_id\":109166,\"boundingbox\":[\"48.1179069\",\"48.3226679\",\"16.181831\",\"16.5775132\"],\"lat\":\"48.2083537\",\"lon\":\"16.3725042\",\"display_name\":\"Vienna, Austria\",\"class\":\"boundary\",\"type\":\"administrative\",\"importance\":0.769412325825045,\"address\":{\"city\":\"Vienna\",\"country\":\"Austria\",\"country_code\":\"at\"},\"extratags\":{\"ele\":\"542\",\"capital\":\"yes\",\"website\":\"https://www.wien.gv.at/\",\"ref:nuts\":\"AT13;AT130\",\"wikidata\":\"Q1741\",\"ISO3166-2\":\"AT-9\",\"wikipedia\":\"de:Wien\",\"population\":\"1897481\",\"ref:at:gkz\":\"90001\",\"ref:nuts:2\":\"AT13\",\"ref:nuts:3\":\"AT130\",\"description\":\"Wien ist die Hauptstadt der Republik Österreich und zugleich eines der neun österreichischen Bundesländer.\",\"linked_place\":\"city\",\"name:prefix:at\":\"Statutarstadt\",\"population:date\":\"2019-01-01\",\"ISO3166-1:alpha2\":\"AT\",\"capital_ISO3166-1\":\"yes\"},\"namedetails\":{\"name\":\"Wien\"}}]";

            var handlerMock = new MockHttpHandler((req) =>
                req.RequestUri.ToString() switch
                {
                    "https://nominatim.openstreetmap.org/lookup?format=json&addressdetails=1&namedetails=1&extratags=1&osm_ids=R109166" => new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
                    },
                    _ => new HttpResponseMessage(HttpStatusCode.NotFound),
                }
            );

            var x = new AddressSearcher(httpMessageHandler: handlerMock);
            var r = x.Lookup(new AddressSearchRequest
            {
                OSMIDs = new List<string>(new[] { "R109166" }),
                BreakdownAddressElements = true,
                ShowAlternativeNames = true,
                ShowExtraTags = true
            });
            r.Wait();

            Assert.AreEqual(1, r.Result.Length);
            Assert.AreEqual(281979440, r.Result[0].PlaceID);
        }
    }
}