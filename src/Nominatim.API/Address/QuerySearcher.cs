using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nominatim.API.Extensions;
using Nominatim.API.Interfaces;
using Nominatim.API.Models;

namespace Nominatim.API.Address
{
	public class QuerySearcher : IQuerySearcher
    {
        private readonly INominatimWebInterface _nominatimWebInterface;

        public string url;
        //jsonv2 not supported for lookup
        private readonly string format = "json";
        /// <summary>
        /// API Key, if you are using an Nominatim service that requires one.
        /// </summary>
        public string key;

        /// <summary>
        /// Constructur
        /// </summary>
        /// <param name="nominatimWebInterface">Injected instance of INominatimWebInterface</param>
        /// <param name="URL">URL to Nominatim service.  Defaults to OSM demo site.</param>
        public QuerySearcher(INominatimWebInterface nominatimWebInterface, string URL = null)
        {
            _nominatimWebInterface = nominatimWebInterface;
            url = URL ?? @"https://nominatim.openstreetmap.org/search";
        }

        /// <summary>
        /// Lookup the address of one or multiple OSM objects like node, way or relation.
        /// </summary>
        /// <param name="req">Search request object</param>
        /// <returns>Array of lookup reponses</returns>
        public async Task<AddressSearchResponse[]> Search(SearchQueryRequest req)
        {
            var result = await _nominatimWebInterface.GetRequest<AddressSearchResponse[]>(url, buildQueryString(req)).ConfigureAwait(false);
            return result;
        }

        private Dictionary<string, string> buildQueryString(SearchQueryRequest r)
        {
            var c = new Dictionary<string, string>();

            c.AddIfSet("format", format);
            c.AddIfSet("key", key);
            c.AddIfSet("accept-language", r.PreferredLanguages);
            c.AddIfSet("addressdetails", r.BreakdownAddressElements);
            c.AddIfSet("namedetails", r.ShowAlternativeNames);
            c.AddIfSet("extratags", r.ShowExtraTags);
            c.AddIfSet("email", r.EmailAddress);

            if (r.queryString.hasValue())
            {
                c.Add("q", r.queryString);
            }
            else
            {
                c.AddIfSet("amenity", r.Amenity);
                c.AddIfSet("street", r.StreetAddress);
                c.AddIfSet("city", r.City);
                c.AddIfSet("county", r.County);
                c.AddIfSet("state", r.State);
                c.AddIfSet("country", r.Country);
                c.AddIfSet("postalcode", r.PostalCode);
            }

            c.AddIfSet("countrycodes", r.CountryCodeSearch);
            c.AddIfSet("limit", r.LimitResults);
            c.AddIfSet("layer", r.Layer);
            c.AddIfSet("featureType", r.FeatureType);
            c.AddIfSet("exclude_place_ids", r.ExcludePlaceIds);

            if (r.ViewBox != null)
            {
                var v = r.ViewBox.Value;
                c.Add("viewbox", $"{v.minLongitude},{v.minLatitude},{v.maxLongitude},{v.maxLatitude}");
            }

            c.AddIfSet("bounded", r.ViewboxBoundedResults);
            c.AddIfSet("polygon_geojson", r.ShowGeoJSON);
            c.AddIfSet("polygon_kml", r.ShowKML);
            c.AddIfSet("polygon_svg", r.ShowSVG);
            c.AddIfSet("polygon_text", r.ShowPolygonText);
            c.AddIfSet("polygon_threshold", r.PolygonThreshold);

            c.AddIfSet("dedupe", r.DedupeResults);

            return c;
        }
	}
}

