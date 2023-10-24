using System.Collections.Generic;
using System.Reflection.Emit;

namespace Nominatim.API.Models {
    public class SearchQueryRequest : BaseNominatimRequest {
        /// <summary>
        /// Query string to search for.  Do not combine with any address fields. Free-form queries are processed first left-to-right and then right-to-left if that fails.
        /// </summary>
        public string queryString { get; set; }
        /// <summary>
        /// If you are making large numbers of request please include a valid email address or alternatively include your email address as part of the User-Agent string.
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        ///     Name and/or type of POI.  Do not combine with query string.
        /// </summary>
        public string Amenity { get; set; }

        /// <summary>
        ///     Street address to search for.  Do not combine with query string.
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        ///     City to search for.  Do not combine with query string.
        /// </summary
        public string City { get; set; }

        /// <summary>
        ///     County to search for.  Do not combine with query string.
        /// </summary>
        public string County { get; set; }

        /// <summary>
        ///     State to search for.  Do not combine with query string.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Country to search for.  Do not combine with query string.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Postalcode to search for.  Do not combine with query string.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        ///     Limit the number of returned results. Default is 10.
        /// </summary>
        public int? LimitResults { get; set; }

        /// <summary>
        ///     Limit search results to a specific country (or a list of countries).
        ///     countrycode should be the ISO 3166-1alpha2 code, e.g.gb for the United Kingdom, de for Germany, etc.
        /// </summary>
        public string CountryCodeSearch { get; set; }

        /// <summary>
        ///     Comma-separated list of: address, poi, railway, natural, manmad
        ///     The address layer contains all places that make up an address: address points with house numbers, streets, inhabited places (suburbs, villages, cities, states tec.) and administrative boundaries.
        ///     The poi layer selects all point of interest.This includes classic POIs like restaurants, shops, hotels but also less obvious features like recycling bins, guideposts or benches.
        ///     The railway layer includes railway infrastructure like tracks. Note that in Nominatim's standard configuration, only very few railway features are imported into the database.
        ///     The natural layer collects feautures like rivers, lakes and mountains while the manmade layer functions as a catch-all for features not covered by the other layers.
        /// </summary>
        public string Layer { get; set; }

        /// <summary>
        ///     one of: country, state, city, settlement
        ///     The featureType allows to have a more fine-grained selection for places from the address layer.
        ///     Results can be restricted to places that make up the 'state', 'country' or 'city' part of an
        ///     address. A featureType of settlement selects any human inhabited feature from 'state' down to
        ///     'neighbourhood'.
        /// </summary>
        public string FeatureType { get; set; }

        /// <summary>
        /// If you do not want certain OSM objects to appear in the search result, give a comma separated list of the place_ids you want to skip. 
        /// </summary>
        public string ExcludePlaceIds { get; set; }

        /// <summary>
        ///     The preferred area to find search results. Any two corner points of the box are accepted in any order as long as
        ///     they span a real box.
        /// </summary>
        public BoundingBox? ViewBox { get; set; }

        /// <summary>
        ///     Restrict the results to only items contained with the viewbox
        /// </summary>
        public bool? ViewboxBoundedResults { get; set; }

        /// <summary>
        ///     Output geometry of results in geojson format.
        /// </summary>
        public bool? ShowGeoJSON { get; set; }

        /// <summary>
        ///     Output geometry of results in kml format.
        /// </summary>
        public bool? ShowKML { get; set; }

        /// <summary>
        ///     Output geometry of results in svg format.
        /// </summary>
        public bool? ShowSVG { get; set; }

        /// <summary>
        ///     Output geometry of results as a WKT.
        /// </summary>
        public bool? ShowPolygonText { get; set; }

        /// <summary>
        ///     When one of the polygon_* outputs is chosen, return a simplified version of the output geometry.
        ///     The parameter describes the tolerance in degrees with which the geometry may differ from the
        ///     original geometry. Topology is preserved in the geometry.
        /// </summary>
        public double? PolygonThreshold { get; set; }

        /// <summary>
        ///     Sometimes you have several objects in OSM identifying the same place or object in reality. The simplest case is a
        ///     street being split in many different OSM ways due to different characteristics.
        ///     Nominatim will attempt to detect such duplicates and only return one match; this is controlled by the dedupe
        ///     parameter which defaults to 1. Since the limit is, for reasons of efficiency, enforced before and not after
        ///     de-duplicating, it is possible that de-duplicating leaves you with less results than requested.
        /// </summary>
        public bool? DedupeResults { get; set; }
    }
}