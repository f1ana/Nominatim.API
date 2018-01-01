namespace Nominatim.API.Extensions {
    public static class StringExtensions {
        internal static bool hasValue(this string str) {
            return !string.IsNullOrEmpty(str);
        }
    }
}