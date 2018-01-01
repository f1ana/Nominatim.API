namespace Nominatim.API.Extensions {
    public static class StringExtensions {
        public static bool hasValue(this string str) {
            return !string.IsNullOrEmpty(str);
        }
    }
}