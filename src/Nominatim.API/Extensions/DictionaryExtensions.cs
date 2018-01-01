using System.Collections.Generic;

namespace Nominatim.API.Extensions {
    public static class DictionaryExtensions {
        public static void AddStringIfHasValue(this Dictionary<string, string> d, string key, string value) {
            if (value.hasValue()) {
                d.Add(key, value);
            }
        }

        public static void AddBoolIfSet(this Dictionary<string, string> d, string key, bool? value) {
            if (!value.HasValue) {
                return;
            }

            d.Add(key, value.Value ? "1" : "0");
        }

        public static void AddIntIfSet(this Dictionary<string, string> d, string key, int? value) {
            if (!value.HasValue) {
                return;
            }

            d.Add(key, $"{value.Value}");
        }
    }
}