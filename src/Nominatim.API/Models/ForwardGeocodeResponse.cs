namespace Nominatim.API.Models {
    public class ForwardGeocodeResponse {
        public int place_id { get; set; }
        public string licence { get; set; }
        public string osm_type { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string display_name { get; set; }
        public string type { get; set; }
    }
}