using PokemonTcgSdk;
using PokemonTcgSdk.Models;
using System.Collections.Generic;
using NUnit.Framework;

namespace PokemonTest
{
    [TestFixture]
    public class PokemonTest
    {
        [Test]
        public void GetAllCards()
        {
            var cards = Card.All();
            var firstCard = cards[0];
            var name = firstCard.Name;

            Assert.IsTrue(cards.Count > 8000);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
            Assert.IsInstanceOf<PokemonCard>(firstCard);// IsInstanceOfType(firstCard, typeof(PokemonCard));
        }

        [Test]
        public void FindPokemonCard()
        {
            var card = Card.Find<Pokemon>("base4-4");
            var name = card.Card.Name;

            Assert.IsTrue(name == "Charizard");
            Assert.IsNotNull(card);
        }

        [Test]
        public void GetPokemonCards()
        {
            var cards = Card.Get<Pokemon>();
            var name = cards.Cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsInstanceOf<Pokemon>(cards);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
        }

        [TestCase("name", "Charizard")]
        [TestCase("name", "Blastoise")]
        [TestCase("name", "Venusaur")]
        [TestCase("set", "sm6")]
        public void GetPokemonCardsByQueryString(string field, string value)
        {
            var query = new Dictionary<string, string>()
            {
                { field, value }
            };
            var cards = Card.Get(query);

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
        public void GetTrainerCards()
        {
            var cards = Card.Get<Trainer>();
            var name = cards.Cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsInstanceOf<Trainer>(cards);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
        }

        [Test]
        public void GetEnergyCards()
        {
            var cards = Card.Get<Energy>();
            var name = cards.Cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsInstanceOf<Energy>(cards);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
        }

        [Test]
        public void GetSubTypes()
        {
            var subTypes = SubTypes.All();

            Assert.IsNotNull(subTypes);
            Assert.IsTrue(subTypes.Count > 1);
        }

        [Test]
        public void GetSuperTypes()
        {
            var superTypes = SuperTypes.All();

            Assert.IsNotNull(superTypes);
            Assert.IsTrue(superTypes.Count > 1);
        }

        [Test]
        public void GetTypes()
        {
            var types = Types.All();

            Assert.IsNotNull(types);
            Assert.IsTrue(types.Count > 1);
        }

        [Test]
        public void GetSets()
        {
            var sets = Sets.All();

            Assert.IsNotNull(sets);
            Assert.IsTrue(sets.Count > 1);
        }

        [Test]
        public void FindSets()
        {
            var query = new Dictionary<string, string>
            {
                {"standardLegal", true.ToString()}
            };

            var sets = Sets.Find(query);
            var name = sets[0].Name;

            Assert.IsNotNull(sets);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
            Assert.IsTrue(sets.Count >= 1);
        }

        [Test]
        public void FindSet()
        {
            var query = new Dictionary<string, string>
            {
                {"name", "Base"}
            };

            var sets = Sets.Find(query);
            var name = sets[0].Name;

            Assert.IsNotNull(sets);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
            Assert.IsTrue(sets.Count >= 1);
        }

        [Test]
        public void AllCardsBySeries()
        {
            var query = new Dictionary<string, string>
            {
                {CardQueryTypes.Series, "XY"}
            };

            var cards = Card.All(query);
            var name = cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
            Assert.IsTrue(cards.Count >= 1);
        }

        [Test]
        public void AllCardsByStandardLegal()
        {
            var query = new Dictionary<string, string>
            {
                {SetQueryTypes.StandardLegal, true.ToString()}
            };

            var cards = Card.All(query);
            var name = cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
            Assert.IsTrue(cards.Count >= 1);
        }
    }
}