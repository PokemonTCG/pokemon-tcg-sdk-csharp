using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using PokemonTcgSdkV2.Client;

namespace PokemonV2Tests
{
    [TestFixture]
    public class PokemonTestV2
    {
        private ApiClient Client { get; } = new ApiClient(null);

        [Test]
        public async Task GetAllCards()
        {
            var response = await Client.QueryCards("");

            Assert.IsTrue(response.Cards.Any());
        }

        [Test]
        public async Task GetAllSets()
        {
            var response = await Client.QueryCards("");

            Assert.IsTrue(response.Cards.Any());
        }
    }
}