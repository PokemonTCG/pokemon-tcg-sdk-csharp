using System.Collections.Generic;
using System.Text.Json.Serialization;
using PokemonTcgSdk.Api.Cardmarket;
using PokemonTcgSdk.Api.Sets;
using PokemonTcgSdk.Api.TcgPlayer;

namespace PokemonTcgSdk.Api.Cards
{
    public class Card
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Supertype { get; set; }

        public IEnumerable<string> Subtypes { get; set; }

        public string Level { get; set; }

        [JsonPropertyName("hp")] public int Hitpoints { get; set; }

        public IEnumerable<string> Types { get; set; }

        public string EvolvesFrom { get; set; }

        public string EvolvesTo { get; set; }

        public IEnumerable<string> Rules { get; set; }

        public AncientTrait AncientTrait { get; set; }

        public IEnumerable<Ability> Abilities { get; set; }

        public IEnumerable<Attack> Attacks { get; set; }

        public IEnumerable<WeaknessOrResistance> Weakness { get; set; }

        public IEnumerable<WeaknessOrResistance> Resistances { get; set; }

        public string RetreatCosts { get; set; }

        public int ConvertedRetreatCost { get; set; }

        public Set Set { get; set; }

        public string Number { get; set; }

        public string Artist { get; set; }

        public string Rarity { get; set; }

        public string FlavorText { get; set; }

        public IEnumerable<int> NationalPokedexNumbers { get; set; }

        public Legalities Legalities { get; set; }

        public Images Images { get; set; }

        public TcgPlayerEntry TcgPlayer { get; set; }

        public CardmarketEntry Cardmarket { get; set; }
    }
}