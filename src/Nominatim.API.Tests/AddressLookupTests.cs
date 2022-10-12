using Newtonsoft.Json;
using Nominatim.API.Address;
using Nominatim.API.Models;
using Nominatim.API.Tests.Helpers;
using NSubstitute;
using NUnit.Framework;

namespace Nominatim.API.Tests;

[TestFixture]
public class AddressLookupTests {
    // Thank you to knom for designing these tests

    private static string baseUrl = @"https://nominatim.openstreetmap.org/lookup";
    
    [Test]
    public async Task AddressLookupTests_TestSuccessfulAddressLookup() {
        // arrange
        const string responseJson = "[{\"place_id\":281979440,\"licence\":\"Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright\",\"osm_type\":\"relation\",\"osm_id\":109166,\"boundingbox\":[\"48.1179069\",\"48.3226679\",\"16.181831\",\"16.5775132\"],\"lat\":\"48.2083537\",\"lon\":\"16.3725042\",\"display_name\":\"Vienna, Austria\",\"class\":\"boundary\",\"type\":\"administrative\",\"importance\":0.769412325825045,\"address\":{\"city\":\"Vienna\",\"country\":\"Austria\",\"country_code\":\"at\"},\"extratags\":{\"ele\":\"542\",\"capital\":\"yes\",\"website\":\"https://www.wien.gv.at/\",\"ref:nuts\":\"AT13;AT130\",\"wikidata\":\"Q1741\",\"ISO3166-2\":\"AT-9\",\"wikipedia\":\"de:Wien\",\"population\":\"1897481\",\"ref:at:gkz\":\"90001\",\"ref:nuts:2\":\"AT13\",\"ref:nuts:3\":\"AT130\",\"description\":\"Wien ist die Hauptstadt der Republik Österreich und zugleich eines der neun österreichischen Bundesländer.\",\"linked_place\":\"city\",\"name:prefix:at\":\"Statutarstadt\",\"population:date\":\"2019-01-01\",\"ISO3166-1:alpha2\":\"AT\",\"capital_ISO3166-1\":\"yes\"},\"namedetails\":{\"name\":\"Wien\"}}]";
        var searchRequest = new AddressSearchRequest {
            OSMIDs = new List<string>(new[] { "R109166" }),
            BreakdownAddressElements = true,
            ShowAlternativeNames = true,
            ShowExtraTags = true
        };
        var expectedSearchDict = new Dictionary<string, string> {
            { "format", "json" },
            { "addressdetails", "1" },
            { "namedetails", "1" },
            { "extratags", "1" },
            { "osm_ids", "R109166" },
        };
        
        var nominatimWebInterface = Substitute.For<INominatimWebInterface>();
        nominatimWebInterface.BaseUrl = StartupSetup.DefaultBaseUrl;
        nominatimWebInterface
            .GetRequest<AddressLookupResponse[]>(
                Arg.Is(baseUrl),
                Arg.Is<Dictionary<string, string>>(x => x.IsEquivalentTo(expectedSearchDict)))
            .Returns( JsonConvert.DeserializeObject<AddressLookupResponse[]>(responseJson));
        var addressSearcher = new AddressSearcher(nominatimWebInterface);
        
        // act
        var result = await addressSearcher.Lookup(searchRequest);

        // assert
        Assert.AreEqual(1, result.Length);
        Assert.AreEqual(281979440, result[0].PlaceID);
    }
    
    // https://stackoverflow.com/questions/3804367/testing-for-equality-between-dictionaries-in-c-sharp
    private bool areDictsEqual(Dictionary<string, string> d1, Dictionary<string, string> d2) =>
        d1.Count == d2.Count && d1.All(
            (d1KV) => d2.TryGetValue(d1KV.Key, out var d2Value) && (
                d1KV.Value == d2Value ||
                d1KV.Value?.Equals(d2Value) == true)
        );
}