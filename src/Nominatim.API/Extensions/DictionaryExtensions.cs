using System.Collections.Generic;

namespace Nominatim.API.Extensions
{
    internal static class DictionaryExtensions {
        public static void AddIfSet<T>(this Dictionary<string, string> d, string key, T value) {
            if (value == null) {
                return;
            }

            if (value is string str) {
                if (!str.hasValue()) {
                    return;
                }
            }

            if (value is bool b) {
                d.Add(key, b ? "1" : "0");
                return;
            }

            d.Add(key, value.ToString());
        }
    }
}