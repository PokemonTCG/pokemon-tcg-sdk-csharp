using System.Collections.Generic;
using System.Text.Json.Serialization;
using PokemonTcgSdkV2.Api.Cardmarket;
using PokemonTcgSdkV2.Api.Sets;
using PokemonTcgSdkV2.Api.TcgPlayer;

namespace PokemonTcgSdkV2.Api.Cards
{
    public class Card
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Supertype { get; set; }

        public IEnumerable<string> Subtypes { get; set; }

        public string Level { get; set; }

        [JsonPropertyName("hp")]
        [JsonNumberHandling(JsonNumberHandling
            .AllowReadingFromString)] // TCGO Api encodes this as a string. -> see https://github.com/PokemonTCG/pokemon-tcg-api/issues/96
        public int? Hitpoints { get; set; }

        public IEnumerable<string> Types { get; set; }

        public string EvolvesFrom { get; set; }

        public IEnumerable<string> EvolvesTo { get; set; }

        public IEnumerable<string> Rules { get; set; }

        public AncientTrait AncientTrait { get; set; }

        public IEnumerable<Ability> Abilities { get; set; }

        public IEnumerable<Attack> Attacks { get; set; }

        public IEnumerable<WeaknessOrResistance> Weakness { get; set; }

        public IEnumerable<WeaknessOrResistance> Resistances { get; set; }

        public string RetreatCosts { get; set; }

        public int? ConvertedRetreatCost { get; set; }

        public Set Set { get; set; }

        public string Number { get; set; }

        public string Artist { get; set; }

        public string Rarity { get; set; }

        public string FlavorText { get; set; }

        public IEnumerable<int?> NationalPokedexNumbers { get; set; }

        public Legalities Legalities { get; set; }

        public CardImages Images { get; set; }

        public TcgPlayerEntry TcgPlayer { get; set; }

        public CardmarketEntry Cardmarket { get; set; }
    }
}