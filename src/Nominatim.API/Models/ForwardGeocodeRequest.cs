namespace Nominatim.API.Models {
    public class ForwardGeocodeRequest {
        public string queryString { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string postalcode { get; set; }

        public FormatEnum format { get; set; }
        public Box viewbox { get; set; }
        public bool bounded { get; set; }
        public bool addressdetails { get; set; }
        public int limit { get; set; }
        public string accept_language { get; set; }


    }
}