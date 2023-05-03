using System.Collections.Generic;

namespace Nominatim.API.Extensions
{
    internal static class DictionaryExtensions {
        public static void AddIfSet<T>(this Dictionary<string, string> d, string key, T value) {
            if (value == null) {
                return;
            }

            d.Add(key, value.ToString());
        }

        public static void AddIfSet(this Dictionary<string, string> d, string key, string value)
        {
            if (!value.hasValue()) {
                return;
            }

            d.Add(key, value.ToString());
        }

        public static void AddIfSet(this Dictionary<string, string> d, string key, bool? value)
        {
            if (value == null) {
                return;
            }

            d.AddIfSet(key, value.Value);
        }

        public static void AddIfSet(this Dictionary<string, string> d, string key, bool value)
        {
            d.Add(key, value ? "1" : "0");
        }
    }
}