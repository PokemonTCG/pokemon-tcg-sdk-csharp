using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonTcgSdk;
using PokemonTcgSdk.Models;
using System.Collections.Generic;

namespace PokemonTest
{
    [TestClass]
    public class PokemonTest
    {
        [TestMethod]
        public void GetAllCards()
        {
            var cards = Card.All();
            var firstCard = cards[0];
            var name = firstCard.Name;

            Assert.IsTrue(cards.Count > 8000);
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
            Assert.IsInstanceOfType(firstCard, typeof(PokemonCard));
        }

        [TestMethod]
        public void FindPokemonCard()
        {
            var card = Card.Find<Pokemon>("base4-4");
            var name = card.Card.Name;

            Assert.IsTrue(name == "Charizard");
            Assert.IsNotNull(card);
        }

        [TestMethod]
        public void GetPokemonCards()
        {
            var cards = Card.Get<Pokemon>();
            var name = cards.Cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsInstanceOfType(cards, typeof(Pokemon));
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
        }

        [TestMethod]
        public void GetPokemonCardsByQueryString()
        {
            Dictionary<string, string> query = new Dictionary<string, string>()
            {
                { "name", "Charizard" }
            };
            var cards = Card.Get(query);

            Assert.IsNotNull(cards);
            Assert.IsInstanceOfType(cards, typeof(Pokemon));
            foreach (var pokemonCard in cards.Cards)
            {
                Assert.IsTrue(pokemonCard.Name.Contains("Charizard"));
            }
        }

        [TestMethod]
        public void GetTrainerCards()
        {
            var cards = Card.Get<Trainer>();
            var name = cards.Cards[0].Name;

            Assert.IsNotNull(cards);
            Assert.IsInstanceOfType(cards, typeof(Trainer));
            Assert.IsFalse(string.IsNullOrWhiteSpace(name));
        }

        [TestMethod]
        public void GetSubTypes()
        {
            var subTypes = SubTypes.All();

            Assert.IsNotNull(subTypes);
            Assert.IsTrue(subTypes.Count > 1);
        }

        [TestMethod]
        public void GetSuperTypes()
        {
            var superTypes = SuperTypes.All();

            Assert.IsNotNull(superTypes);
            Assert.IsTrue(superTypes.Count > 1);
        }

        [TestMethod]
        public void GetTypes()
        {
            var types = Types.All();

            Assert.IsNotNull(types);
            Assert.IsTrue(types.Count > 1);
        }

        [TestMethod]
        public void GetSets()
        {
            var sets = Sets.All();

            Assert.IsNotNull(sets);
            Assert.IsTrue(sets.Count > 1);
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
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