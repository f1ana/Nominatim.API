using Newtonsoft.Json;

using Nominatim.API.Contracts;
using Nominatim.API.Models;

using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Nominatim.API.Tests
{
    public class PrivateContractResolverTests
    {
        [Test]
        public void PrivateContractResolverTest_ParallelismShouldWork()
        {
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new PrivateContractResolver()
            };

            var random = new Random(69);

            AddressResult[] addresses = new AddressResult[10000];

            for (int i = 0; i < 10000; i++)
            {
                addresses[i] = new AddressResult
                {
                    City = random.Next(100000).ToString(),
                    Country = random.Next(100000).ToString(),
                    CountryCode = random.Next(100000).ToString(),
                    County = random.Next(100000).ToString(),
                    District = random.Next(100000).ToString(),
                    Hamlet = random.Next(100000).ToString(),
                    HouseNumber = random.Next(100000).ToString(),
                    Name = random.Next(100000).ToString(),
                    Neighborhood = random.Next(100000).ToString(),
                    Pedestrian = random.Next(100000).ToString(),
                    PostCode = random.Next(100000).ToString(),
                    Region = random.Next(100000).ToString(),
                    Road = random.Next(100000).ToString(),
                    State = random.Next(100000).ToString(),
                    Suburb = random.Next(100000).ToString(),
                    Town = random.Next(100000).ToString(),
                    Village = random.Next(100000).ToString(),
                };
            }

            var jsons = addresses.Select(JsonConvert.SerializeObject).ToArray();

            AddressResult[] result = new AddressResult[addresses.Length];

            Parallel.For(0, addresses.Length, index =>
            {
                result[index] = JsonConvert.DeserializeObject<AddressResult>(jsons[index], jsonSerializerSettings)!;
            });

            Assert.AreEqual(addresses.Length, result.Length);

            for (int i = 0; i < addresses.Length; i++)
            {
                Assert.AreEqual(addresses[i].City, result[i].City);
                Assert.AreEqual(addresses[i].Country, result[i].Country);
                Assert.AreEqual(addresses[i].CountryCode, result[i].CountryCode);
                Assert.AreEqual(addresses[i].County, result[i].County);
                Assert.AreEqual(addresses[i].District, result[i].District);
                Assert.AreEqual(addresses[i].Hamlet, result[i].Hamlet);
                Assert.AreEqual(addresses[i].HouseNumber, result[i].HouseNumber);
                Assert.AreEqual(addresses[i].Name, result[i].Name);
                Assert.AreEqual(addresses[i].Neighborhood, result[i].Neighborhood);
                Assert.AreEqual(addresses[i].Pedestrian, result[i].Pedestrian);
                Assert.AreEqual(addresses[i].PostCode, result[i].PostCode);
                Assert.AreEqual(addresses[i].Region, result[i].Region);
                Assert.AreEqual(addresses[i].Road, result[i].Road);
                Assert.AreEqual(addresses[i].State, result[i].State);
                Assert.AreEqual(addresses[i].Suburb, result[i].Suburb);
                Assert.AreEqual(addresses[i].Town, result[i].Town);
                Assert.AreEqual(addresses[i].Village, result[i].Village);
            }
        }
    }
}
