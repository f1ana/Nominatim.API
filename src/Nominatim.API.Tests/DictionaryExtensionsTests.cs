using NUnit.Framework;
using Nominatim.API.Extensions;

namespace Nominatim.API.Tests
{
    public class DictionaryExtensionsTests
    {
        [Test]
        [TestCase(true, "1")]
        [TestCase(false, "0")]
        public void DictionaryExtensionsTest_TestBool(bool value, string expect)
        {
            var dict = new Dictionary<string, string>();

            var key = "key";

            dict.AddIfSet(key, value);

            Assert.IsTrue(dict.ContainsKey(key));
            Assert.AreEqual(expect, dict[key]);
        }

        [Test]
        [TestCase(true, "1")]
        [TestCase(false, "0")]
        public void DictionaryExtensionsTest_TestNullableBoolWithValue(bool? value, string expect)
        {
            var dict = new Dictionary<string, string>();

            var key = "key";

            dict.AddIfSet(key, value);

            Assert.IsTrue(dict.ContainsKey(key));
            Assert.AreEqual(expect, dict[key]);
        }

        public void DictionaryExtensionsTest_TestNullableBoolEqualsNull()
        {
            var dict = new Dictionary<string, string>();

            var key = "key";
            bool? value = null;

            dict.AddIfSet(key, value);

            Assert.IsFalse(dict.ContainsKey(key));
        }
    }
}
