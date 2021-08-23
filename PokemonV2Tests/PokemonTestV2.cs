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

        [Test]
        public async Task FindCard()
        {
            var response = await Client.FetchById<Card>("swsh45sv-SV044");

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);

            Assert.AreEqual("Morpeko", response.Data.Name);
        }
    }
}