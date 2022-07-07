namespace Nominatim.API.Tests.Helpers; 

public static class DictionaryComparer {
    public static bool IsEquivalentTo(this Dictionary<string, string> d1, Dictionary<string, string> d2) =>
        d1.Count == d2.Count && d1.All(
            (d1KV) => d2.TryGetValue(d1KV.Key, out var d2Value) && (
                d1KV.Value == d2Value ||
                d1KV.Value?.Equals(d2Value) == true)
        );
}