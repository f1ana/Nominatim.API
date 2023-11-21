using Newtonsoft.Json;
using Nominatim.API.Address;
using Nominatim.API.Interfaces;
using Nominatim.API.Models;
using Nominatim.API.Tests.Helpers;
using NSubstitute;
using NUnit.Framework;

namespace Nominatim.API.Tests;

[TestFixture]
public class QuerySearchTest {
    // Thank you to knom for designing these tests

    private static string baseUrl = @"https://nominatim.openstreetmap.org/search";
    
    [Test]
    public async Task AddressLookupTests_TestSuccessfulAddressLookup() {
        // arrange
        const string responseJson = "[{\"place_id\":50893905,\"licence\":\"Data © OpenStreetMap contributors, ODbL 1.0. http://osm.org/copyright\",\"osm_type\":\"way\",\"osm_id\":480632416,\"lat\":\"-33.8275368\",\"lon\":\"151.0820211\",\"class\":\"highway\",\"type\":\"cycleway\",\"place_rank\":27,\"importance\":0.282582546755277,\"addresstype\":\"road\",\"name\":\"Bennelong Bridge\",\"display_name\":\"Bennelong Bridge, Rhodes, Inner West, Sydney, City of Canada Bay Council, New South Wales, 2138, Australia\",\"address\":{\"road\":\"Bennelong Bridge\",\"suburb\":\"Rhodes\",\"borough\":\"Inner West\",\"city\":\"Sydney\",\"municipality\":\"City of Canada Bay Council\",\"state\":\"New South Wales\",\"ISO3166-2-lvl4\":\"AU-NSW\",\"postcode\":\"2138\",\"country\":\"Australia\",\"country_code\":\"au\"},\"extratags\":{\"lit\": \"yes\", \"foot\": \"designated\", \"layer\": \"1\", \"bridge\": \"yes\", \"oneway\": \"no\", \"bicycle\": \"designated\", \"surface\": \"asphalt\", \"website\": \"http://www.homebushbaybridge.com.au/\", \"wikidata\": \"Q24034546\", \"wikipedia\": \"en:Bennelong Bridge\", \"segregated\": \"no\", \"motor_vehicle\": \"no\"},\"namedetails\":{\"name\": \"Bennelong Bridge\"},\"boundingbox\":[\"-33.8280066\",\"-33.8265447\",\"151.0803637\",\"151.0834581\"]},{\"place_id\":50912415,\"licence\":\"Data © OpenStreetMap contributors, ODbL 1.0. http://osm.org/copyright\",\"osm_type\":\"way\",\"osm_id\":260879699,\"lat\":\"-33.8345637\",\"lon\":\"151.0756696\",\"class\":\"highway\",\"type\":\"tertiary\",\"place_rank\":26,\"importance\":0.10000999999999993,\"addresstype\":\"road\",\"name\":\"Bennelong Parkway\",\"display_name\":\"Bennelong Parkway, Mariners cove, Wentworth Point, Sydney, City of Parramatta Council, New South Wales, 2127, Australia\",\"address\":{\"road\":\"Bennelong Parkway\",\"residential\":\"Mariners cove\",\"suburb\":\"Wentworth Point\",\"city\":\"Sydney\",\"municipality\":\"City of Parramatta Council\",\"state\":\"New South Wales\",\"ISO3166-2-lvl4\":\"AU-NSW\",\"postcode\":\"2127\",\"country\":\"Australia\",\"country_code\":\"au\"},\"extratags\":{\"surface\": \"asphalt\", \"maxspeed\": \"50\"},\"namedetails\":{\"name\": \"Bennelong Parkway\"},\"boundingbox\":[\"-33.8345637\",\"-33.8342636\",\"151.0753893\",\"151.0756696\"]},{\"place_id\":50757867,\"licence\":\"Data © OpenStreetMap contributors, ODbL 1.0. http://osm.org/copyright\",\"osm_type\":\"way\",\"osm_id\":1172876571,\"lat\":\"-33.8326589\",\"lon\":\"151.0732907\",\"class\":\"highway\",\"type\":\"tertiary\",\"place_rank\":26,\"importance\":0.10000999999999993,\"addresstype\":\"road\",\"name\":\"Bennelong Parkway\",\"display_name\":\"Bennelong Parkway, Wentworth Point, Sydney, City of Parramatta Council, New South Wales, 2127, Australia\",\"address\":{\"road\":\"Bennelong Parkway\",\"suburb\":\"Wentworth Point\",\"city\":\"Sydney\",\"municipality\":\"City of Parramatta Council\",\"state\":\"New South Wales\",\"ISO3166-2-lvl4\":\"AU-NSW\",\"postcode\":\"2127\",\"country\":\"Australia\",\"country_code\":\"au\"},\"extratags\":{\"oneway\": \"yes\", \"surface\": \"asphalt\", \"maxspeed\": \"50\"},\"namedetails\":{\"name\": \"Bennelong Parkway\"},\"boundingbox\":[\"-33.8327590\",\"-33.8326589\",\"151.0732907\",\"151.0734140\"]},{\"place_id\":50978437,\"licence\":\"Data © OpenStreetMap contributors, ODbL 1.0. http://osm.org/copyright\",\"osm_type\":\"way\",\"osm_id\":137902519,\"lat\":\"-33.8308044\",\"lon\":\"151.0717921\",\"class\":\"highway\",\"type\":\"tertiary_link\",\"place_rank\":27,\"importance\":0.07500999999999991,\"addresstype\":\"road\",\"name\":\"Bennelong Parkway\",\"display_name\":\"Bennelong Parkway, Wentworth Point, Sydney, City of Parramatta Council, New South Wales, 2127, Australia\",\"address\":{\"road\":\"Bennelong Parkway\",\"suburb\":\"Wentworth Point\",\"city\":\"Sydney\",\"municipality\":\"City of Parramatta Council\",\"state\":\"New South Wales\",\"ISO3166-2-lvl4\":\"AU-NSW\",\"postcode\":\"2127\",\"country\":\"Australia\",\"country_code\":\"au\"},\"extratags\":{\"lanes\": \"1\", \"oneway\": \"yes\", \"surface\": \"asphalt\", \"cycleway:left\": \"lane\", \"cycleway:right\": \"no\"},\"namedetails\":{\"name\": \"Bennelong Parkway\"},\"boundingbox\":[\"-33.8313697\",\"-33.8300687\",\"151.0717921\",\"151.0719481\"]},{\"place_id\":50831895,\"licence\":\"Data © OpenStreetMap contributors, ODbL 1.0. http://osm.org/copyright\",\"osm_type\":\"way\",\"osm_id\":260879705,\"lat\":\"-33.834954\",\"lon\":\"151.0760344\",\"class\":\"highway\",\"type\":\"tertiary\",\"place_rank\":26,\"importance\":0.10000999999999993,\"addresstype\":\"road\",\"name\":\"Bennelong Parkway\",\"display_name\":\"Bennelong Parkway, Sydney Olympic Park, Sydney, City of Parramatta Council, New South Wales, 2127, Australia\",\"address\":{\"road\":\"Bennelong Parkway\",\"suburb\":\"Sydney Olympic Park\",\"city\":\"Sydney\",\"municipality\":\"City of Parramatta Council\",\"state\":\"New South Wales\",\"ISO3166-2-lvl4\":\"AU-NSW\",\"postcode\":\"2127\",\"country\":\"Australia\",\"country_code\":\"au\"},\"extratags\":{\"foot\": \"designated\", \"layer\": \"1\", \"bridge\": \"yes\", \"surface\": \"asphalt\", \"maxspeed\": \"50\"},\"namedetails\":{\"name\": \"Bennelong Parkway\"},\"boundingbox\":[\"-33.8349540\",\"-33.8345637\",\"151.0756696\",\"151.0760344\"]}]";
        var searchRequest = new SearchQueryRequest {
            queryString = "Bennelong Point, Sydney NSW 2000",
            CountryCodeSearch = "AU",
            BreakdownAddressElements = true,
            ShowAlternativeNames = true,
            ShowExtraTags = true
        };
        var expectedSearchDict = new Dictionary<string, string> {
            { "q", "Bennelong Point, Sydney NSW 2000" },
            { "format", "json" },
            { "addressdetails", "1" },
            { "namedetails", "1" },
            { "extratags", "1" },
            { "countrycodes", "AU" },
        };
        
        var nominatimWebInterface = Substitute.For<INominatimWebInterface>();
        nominatimWebInterface
            .GetRequest<AddressSearchResponse[]>(
                Arg.Is(baseUrl), 
                Arg.Is<Dictionary<string, string>>(x => x.IsEquivalentTo(expectedSearchDict)))
            .Returns( JsonConvert.DeserializeObject<AddressSearchResponse[]>(responseJson));
        var addressSearcher = new QuerySearcher(nominatimWebInterface);
        
        // act
        var result = await addressSearcher.Search(searchRequest);

        // assert
        Assert.AreEqual(5, result.Length);
        Assert.AreEqual(50893905, result[0].PlaceID);
    }

}