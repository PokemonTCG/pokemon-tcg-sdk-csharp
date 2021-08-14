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
        public async Task GetAllCardsAsync()
        {
            var cards = await Client.QueryCards("");

            Assert.IsTrue(cards.Any());
        }
    }
}