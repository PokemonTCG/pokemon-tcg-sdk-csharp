using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PokemonTcgSdkV2.Api.Cards;
using PokemonTcgSdkV2.Api.Sets;
using PokemonTcgSdkV2.Client;

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
        public async Task FindCard(string cardId, string cardName)
        {
            var response = await Client.FetchById<Card>(cardId);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);

            Assert.AreEqual(cardName, response.Data.Name);
        }
    }
}