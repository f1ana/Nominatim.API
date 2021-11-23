using System.Diagnostics;
using System.Text;
using System.Net;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nominatim.API.Geocoders;
using Nominatim.API.Models;

namespace Nominatim.API.Tests
{
    [TestClass]
    public class ForwardGeocoderMockTests
    {
        [TestMethod]
        public void TestSuccessfulForwardGeocode()
        {
            const string responseJson = "[{\"place_id\":321574407,\"licence\":\"Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright\",\"osm_type\":\"way\",\"osm_id\":995417378,\"boundingbox\":[\"38.8637386\",\"38.8637409\",\"-76.9467576\",\"-76.9467515\"],\"lat\":\"38.8637409\",\"lon\":\"-76.9467576\",\"display_name\":\"Pennsylvania Avenue, Washington, District of Columbia, 20746-8001, United States\",\"place_rank\":26,\"category\":\"highway\",\"type\":\"trunk\",\"importance\":0.41000000000000003,\"address\":{\"road\":\"Pennsylvania Avenue\",\"city\":\"Washington\",\"state\":\"District of Columbia\",\"postcode\":\"20746-8001\",\"country\":\"United States\",\"country_code\":\"us\"},\"geojson\":{\"type\":\"LineString\",\"coordinates\":[[-76.9467515,38.8637386],[-76.9467576,38.8637409]]},\"extratags\":{},\"namedetails\":{\"ref\":\"MD 4\",\"name\":\"Pennsylvania Avenue\",\"name:en\":\"Pennsylvania Avenue\"}},{\"place_id\":270072998,\"licence\":\"Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright\",\"osm_type\":\"way\",\"osm_id\":899927559,\"boundingbox\":[\"38.8958906\",\"38.8959158\",\"-77.030956\",\"-77.0308642\"],\"lat\":\"38.8959025\",\"lon\":\"-77.0309076\",\"display_name\":\"Pennsylvania Avenue, Washington, District of Columbia, 20045, United States\",\"place_rank\":27,\"category\":\"highway\",\"type\":\"path\",\"importance\":0.385,\"address\":{\"road\":\"Pennsylvania Avenue\",\"city\":\"Washington\",\"state\":\"District of Columbia\",\"postcode\":\"20045\",\"country\":\"United States\",\"country_code\":\"us\"},\"geojson\":{\"type\":\"LineString\",\"coordinates\":[[-77.0308642,38.8958906],[-77.0309076,38.8959025],[-77.030956,38.8959158]]},\"extratags\":{\"surface\":\"paved\"},\"namedetails\":{\"name\":\"Pennsylvania Avenue\"}}]";

            var handlerMock = new MockHttpHandler((req) =>
                req.RequestUri.ToString() switch
                {
                    "https://nominatim.openstreetmap.org/search?format=jsonv2&q=1600 Pennsylvania Avenue, Washington, DC&addressdetails=1&namedetails=1&polygon_geojson=1&extratags=1" => new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
                    },
                    _ => new HttpResponseMessage(HttpStatusCode.NotFound),
                }
            );

            var x = new ForwardGeocoder(httpMessageHandler: handlerMock);

            var r = x.Geocode(new ForwardGeocodeRequest
            {
                queryString = "1600 Pennsylvania Avenue, Washington, DC",

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });
            r.Wait();

            Assert.AreEqual(2, r.Result.Length);
            Assert.AreEqual(321574407, r.Result[0].PlaceID);
        }

        [TestMethod]
        public void TestSuccessfulReverseGeocodeBuilding()
        {
            const string responseJson = "{\"place_id\":159859857,\"licence\":\"Data © OpenStreetMap contributors, ODbL 1.0. https://osm.org/copyright\",\"osm_type\":\"way\",\"osm_id\":238241022,\"lat\":\"38.897699700000004\",\"lon\":\"-77.03655315\",\"place_rank\":30,\"category\":\"office\",\"type\":\"government\",\"importance\":0.6347211541681101,\"addresstype\":\"office\",\"name\":\"White House\",\"display_name\":\"White House, 1600, Pennsylvania Avenue Northwest, Washington, District of Columbia, 20500, United States\",\"address\":{\"office\":\"White House\",\"house_number\":\"1600\",\"road\":\"Pennsylvania Avenue Northwest\",\"city\":\"Washington\",\"state\":\"District of Columbia\",\"postcode\":\"20500\",\"country\":\"United States\",\"country_code\":\"us\"},\"extratags\":{\"image\":\"http://upload.wikimedia.org/wikipedia/commons/a/af/WhiteHouseSouthFacade.JPG\",\"level\":\"-1-3\",\"website\":\"https://www.whitehouse.gov/\",\"wikidata\":\"Q35525\",\"architect\":\"James Hoban\",\"dcgis:aid\":\"293211\",\"dcgis:gis\":\"HSE_0001\",\"dcgis:ssl\":\"0187S 0800\",\"dcgis:url\":\"http://www.planning.dc.gov/planning/cwp/view,a,1284,q,570748,planningNav_GID,1706,planningNav,%7C33515%7C.asp\",\"wikipedia\":\"en:White House\",\"dcgis:area\":\"5170.992039\",\"government\":\"presidency\",\"start_date\":\"1800-11-01\",\"wheelchair\":\"yes\",\"dcgis:label\":\"The White House\",\"dcgis:length\":\"635.024279062\",\"dcgis:address\":\"1600 Pennsylvania Ave, NW\",\"dcgis:objectid\":\"569\",\"dcgis:list_info\":\"Reg\",\"dcgis:nr_eligibl\":\"0\",\"dcgis:update_date\":\"Wed Feb 01 00:00:00 UTC 2006\"},\"namedetails\":{\"name\":\"White House\",\"name:br\":\"Ti Gwenn\",\"name:cs\":\"Bílý dům\",\"name:de\":\"Weißes Haus\",\"name:en\":\"White House\",\"name:fa\":\"کاخ سفید\",\"name:fi\":\"Valkoinen talo\",\"name:fr\":\"Maison Blanche\",\"name:hi\":\"व्हाइट हाउस\",\"name:hr\":\"Bijela kuća\",\"name:hu\":\"Fehér Ház\",\"name:it\":\"Casa Bianca\",\"name:ja\":\"ホワイトハウス\",\"name:ko\":\"백악관\",\"name:ku\":\"Qesra Spî\",\"name:lt\":\"Baltieji Rūmai\",\"name:nl\":\"Witte Huis\",\"name:pt\":\"Casa Branca\",\"name:ro\":\"Casa Albă\",\"name:ru\":\"Белый дом\",\"name:sk\":\"Biely dom\",\"name:sv\":\"Vita huset\",\"name:tr\":\"Beyaz Saray\",\"name:uk\":\"Білий дім\",\"name:zh\":\"白宫\",\"alt_name:hr\":\"Bila kuća\",\"addr:housename\":\"The White House\"},\"boundingbox\":[\"38.8974908\",\"38.897911\",\"-77.0368537\",\"-77.0362519\"],\"geojson\":{\"type\":\"Polygon\",\"coordinates\":[[[-77.0368537,38.8975574],[-77.0367914,38.8975573],[-77.0367838,38.8975573],[-77.0367445,38.8975573],[-77.0367006,38.8975572],[-77.0366639,38.8975572],[-77.0366562,38.8975401],[-77.0366445,38.8975253],[-77.036636,38.8975176],[-77.0366217,38.8975078],[-77.0366061,38.8975003],[-77.0365845,38.8974938],[-77.0365616,38.8974908],[-77.0365503,38.8974911],[-77.0365387,38.8974914],[-77.0365194,38.897495],[-77.0364977,38.8975026],[-77.0364832,38.8975103],[-77.0364701,38.8975201],[-77.036461,38.8975292],[-77.0364517,38.8975421],[-77.0364451,38.897557],[-77.0363987,38.8975569],[-77.036321,38.8975569],[-77.0363105,38.8975569],[-77.036252,38.897557],[-77.0362519,38.897598],[-77.0362528,38.897621],[-77.0362528,38.8976491],[-77.0362528,38.8976492],[-77.0362528,38.8976776],[-77.0362528,38.8976962],[-77.0362528,38.8977032],[-77.0362528,38.8977034],[-77.0362527,38.8977387],[-77.0362527,38.8977562],[-77.0362527,38.8977606],[-77.0362526,38.8977951],[-77.0363111,38.8977952],[-77.0363412,38.8977952],[-77.0363982,38.8977952],[-77.0363984,38.8977953],[-77.0364305,38.8977953],[-77.036455,38.8977953],[-77.0364549,38.8978187],[-77.0364548,38.8978339],[-77.0364548,38.8978441],[-77.0364548,38.8978548],[-77.0364547,38.897883],[-77.0364547,38.8978949],[-77.0364547,38.8979108],[-77.0365326,38.8979109],[-77.0365602,38.8979109],[-77.036643,38.897911],[-77.036643,38.8978966],[-77.036643,38.897885],[-77.0366428,38.8978553],[-77.0366428,38.8978448],[-77.0366427,38.8978343],[-77.0366429,38.8978268],[-77.0366432,38.8978169],[-77.0366432,38.8977955],[-77.0366679,38.8977955],[-77.036703,38.8977956],[-77.0367461,38.8977956],[-77.0367946,38.8977956],[-77.0368114,38.8977958],[-77.0368535,38.8977959],[-77.0368537,38.8977338],[-77.0368535,38.8977184],[-77.0368535,38.8977036],[-77.0368535,38.8976869],[-77.0368535,38.8976765],[-77.0368535,38.8976497],[-77.0368536,38.8976282],[-77.0368536,38.8975961],[-77.0368537,38.8975574]]]}}";

            var handlerMock = new MockHttpHandler((req) =>
                req.RequestUri.ToString() switch
                {
                    "https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat=38.8976763&lon=-77.0365298&addressdetails=1&namedetails=1&polygon_geojson=1&extratags=1" => new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new StringContent(responseJson, Encoding.UTF8, "application/json")
                    },
                    _ => new HttpResponseMessage(HttpStatusCode.NotFound),
                }
            );

            var y = new ReverseGeocoder(httpMessageHandler: handlerMock);

            var r2 = y.ReverseGeocode(new ReverseGeocodeRequest
            {
                Longitude = -77.0365298,
                Latitude = 38.8976763,

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });
            r2.Wait();

            Assert.AreEqual(159859857, r2.Result.PlaceID);
        }


        [TestMethod]
        public void TestSuccessfulReverseGeocodeRoad()
        {
            var z = new ReverseGeocoder();

            var r3 = z.ReverseGeocode(new ReverseGeocodeRequest
            {
                Longitude = -58.7051622809683,
                Latitude = -34.440723129053,

                BreakdownAddressElements = true,
                ShowExtraTags = true,
                ShowAlternativeNames = true,
                ShowGeoJSON = true
            });
            r3.Wait();

            Assert.IsTrue((r3.Result.PlaceID > 0) && (r3.Result.Category == "highway") && (r3.Result.ClassType == "milestone"));
        }
    }
}