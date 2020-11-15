using PokemonTcgSdk;
using PokemonTcgSdk.Models;
using System.Collections.Generic;
using NUnit.Framework;
using System.Threading.Tasks;

namespace PokemonTest
{
    [TestFixture]
    public class PokemonAsyncTest
    {
        [Test]
        public async Task GetAllCardsAsync()
        {
            var cards = await Card.AllAsync();
            var firstCard = cards[0];
            var name = firstCard.Name;

            Assert.IsTrue(cards.Count > 8000);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
            Assert.IsInstanceOf<PokemonCard>(firstCard);// IsInstanceOfType(firstCard, typeof(PokemonCard));
        }

        [Test]
        public async Task FindPokemonCardAsync()
        {
            var card = await Card.FindAsync<Pokemon>("base4-4");
            var name = card.Card.Name;

            Assert.IsTrue(name == "Charizard");
            Assert.IsNotNull(card);
        }

        [Test]
        public async Task GetPokemonCardsAsync()
        {
            var cards = await Card.GetAsync<Pokemon>();
            var name = cards.Cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsInstanceOf<Pokemon>(cards);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
        }

        [TestCase("name", "Charizard")]
        [TestCase("name", "Blastoise")]
        [TestCase("name", "Venusaur")]
        [TestCase("set", "sm6")]
        public async Task GetPokemonCardsByQueryStringAsync(string field, string value)
        {
            var query = new Dictionary<string, string>()
            {
                { field, value }
            };
            var cards = await Card.GetAsync(query);

            Assert.IsNotNull(cards);
            Assert.IsInstanceOf<Pokemon>(cards);
            foreach (var pokemonCard in cards.Cards)
            {
                switch (field)
                {
                    case "name":
                        Assert.IsTrue(pokemonCard.Name.Contains(value));
                        break;
                    case "set":
                        Assert.IsTrue(pokemonCard.Set.Contains(value));
                        break;
                    default:
                        Assert.IsTrue(!string.IsNullOrWhiteSpace(pokemonCard.Id));
                        break;
                }
            }
        }

        [Test]
        public async Task GetTrainerCardsAsync()
        {
            var cards = await Card.GetAsync<Trainer>();
            var name = cards.Cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsInstanceOf<Trainer>(cards);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
        }

        [Test]
        public async Task GetEnergyCardsAsync()
        {
            var cards = await Card.GetAsync<Energy>();
            var name = cards.Cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsInstanceOf<Energy>(cards);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
        }

        [Test]
        public async Task GetSubTypesAsync()
        {
            var subTypes = await SubTypes.AllAsync();

            Assert.IsNotNull(subTypes);
            Assert.IsTrue(subTypes.Count > 1);
        }

        [Test]
        public async Task GetSuperTypesAsync()
        {
            var superTypes = await SuperTypes.AllAsync();

            Assert.IsNotNull(superTypes);
            Assert.IsTrue(superTypes.Count > 1);
        }

        [Test]
        public async Task GetTypesAsync()
        {
            var types = await Types.AllAsync();

            Assert.IsNotNull(types);
            Assert.IsTrue(types.Count > 1);
        }

        [Test]
        public async Task GetSetsAsync()
        {
            var sets = await Sets.AllAsync();

            Assert.IsNotNull(sets);
            Assert.IsTrue(sets.Count > 1);
        }

        [Test]
        public async Task FindSetsAsync()
        {
            var query = new Dictionary<string, string>
            {
                {"standardLegal", true.ToString()}
            };

            var sets = await Sets.FindAsync(query);
            var name = sets[0].Name;

            Assert.IsNotNull(sets);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
            Assert.IsTrue(sets.Count >= 1);
        }

        [Test]
        public async Task FindSetAsync()
        {
            var query = new Dictionary<string, string>
            {
                {"name", "Base"}
            };

            var sets = await Sets.FindAsync(query);
            var name = sets[0].Name;

            Assert.IsNotNull(sets);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
            Assert.IsTrue(sets.Count >= 1);
        }

        [Test]
        public async Task AllCardsBySeriesAsync()
        {
            var query = new Dictionary<string, string>
            {
                {CardQueryTypes.Series, "XY"}
            };

            var cards = await Card.AllAsync(query);
            var name = cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
            Assert.IsTrue(cards.Count >= 1);
        }

        [Test]
        public async Task AllCardsByStandardLegalAsync()
        {
            var query = new Dictionary<string, string>
            {
                {SetQueryTypes.StandardLegal, true.ToString()}
            };

            var cards = await Card.AllAsync(query);
            var name = cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
            Assert.IsTrue(cards.Count >= 1);
        }
    }
}