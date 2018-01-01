using System.Collections.Generic;

namespace Nominatim.API.Extensions {
    internal static class DictionaryExtensions {
        public static void AddIfSet<T>(this Dictionary<string, string> d, string key, T value) {
            if (value == null) {
                return;
            }

            var type = typeof(T);

            if (type == typeof(string)) {
                var s = value as string;
                if (!s.hasValue()) {
                    return;
                }
            }

            if (type == typeof(bool) || type == typeof(bool?)) {
                var b = value as bool?;
                d.Add(key, b.HasValue && b.Value ? "1" : "0");
                return;
            }

            d.Add(key, $"{value}");
        }
    }
}