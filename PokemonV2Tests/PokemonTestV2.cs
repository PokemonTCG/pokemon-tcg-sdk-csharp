using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PokemonTcgSdkV2.Api.Cards;
using PokemonTcgSdkV2.Api.Sets;
using PokemonTcgSdkV2.Client;
using PokemonTcgSdkV2.Utils;

namespace PokemonV2Tests
{
    [TestFixture]
    public class PokemonTestV2
    {
        private ApiClient Client { get; } = new ApiClient(null);

        [Test]
        public async Task FetchCards()
        {
            var response = await Client.FetchData<Card>();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(response.Data.Any());
        }

        [Test]
        public async Task FetchSets()
        {
            var response = await Client.FetchData<Set>();

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.IsTrue(response.Data.Any());
        }

        [TestCase("swsh45sv-SV044", "Morpeko")]
        [TestCase("base4-4", "Charizard")]
        public async Task FindCard(string cardId, string expectedCardName)
        {
            var response = await Client.FetchById<Card>(cardId);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);

            Assert.AreEqual(expectedCardName, response.Data.Name);
        }

        [TestCase("base1", "Base")]
        [TestCase("sm12", "Cosmic Eclipse")]
        public async Task FindSet(string setId, string expectedSetName)
        {
            var response = await Client.FetchById<Set>(setId);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);

            Assert.AreEqual(expectedSetName, response.Data.Name);
        }

        [Test]
        public async Task FetchMultiplePages()
        {
            var response = await Client.FetchData<Card>();

            Assert.IsNotNull(response);
            Assert.AreEqual(1, response.Page);
            Assert.IsTrue(response.TotalPages > 1);

            response = await response.FetchNextPage();
            Assert.IsNotNull(response);
            Assert.AreEqual(2, response.Page);

            response = await response.FetchPage(response.TotalPages);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.TotalPages, response.Page);
        }

        [TestCase("name", "charizard", "(name:charizard)")]
        [TestCase("name", "charizard v", @"(name:""charizard v"")")]
        [TestCase("name", @"""charizard v""", @"(name:""charizard v"")")]
        public void TestQueryBuilderSimple(string key, string value, string expected)
        {
            var query = QueryBuilder.StartQuery(key, value);

            Assert.AreEqual(expected, query.BuildQuery());
        }

        [TestCase(new[] {"name", "name"}, new[] {"charizard", "morpeko"}, "(name:charizard OR name:morpeko)")]
        [TestCase(new[] {"name", "name"}, new[] {"charizard v", "morpeko v"},
            @"(name:""charizard v"" OR name:""morpeko v"")")]
        [TestCase(new[] {"name", "set.id"}, new[] {"charizard", "swsh4-25"}, "(name:charizard) (set.id:swsh4-25)")]
        [TestCase(new[] {"name", "set.id", "name"}, new[] {"charizard", "swsh4-25", "lugia"},
            "(name:charizard OR name:lugia) (set.id:swsh4-25)")]
        public void TestQueryBuilderMultipleValues(string[] keys, string[] values, string expected)
        {
            Assert.AreEqual(keys.Length, values.Length);

            var query = new QueryBuilder();

            for (var i = 0; i < keys.Length; i++) query.Add(keys[i], values[i]);

            Assert.AreEqual(expected, query.BuildQuery());
        }
    }
}