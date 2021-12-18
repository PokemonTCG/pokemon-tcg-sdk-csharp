using System.Collections.Generic;
using System.Text.Json.Serialization;
using PokemonTcgSdkV2.Api.Cardmarket;
using PokemonTcgSdkV2.Api.Sets;
using PokemonTcgSdkV2.Api.TcgPlayer;
using PokemonTcgSdkV2.Client.Endpoints;

namespace PokemonTcgSdkV2.Api.Cards
{
    /// <summary>
    ///     Represents a single Pokémon card.
    /// </summary>
    public class Card : FetchableApiObject, IApiObjectWithId
    {
        static Card()
        {
            EndpointFactory.RegisterTypeEndpoint<Card>(new CardEndpoint());
        }

        /// <summary>
        ///     The name of the card.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The supertype of the card, such as Pokémon, Energy, or Trainer.
        /// </summary>
        public string Supertype { get; set; }

        /// <summary>
        ///     A list of subtypes, such as Basic, EX, Mega, Rapid Strike, etc.
        /// </summary>
        public IEnumerable<string> Subtypes { get; set; }

        /// <summary>
        ///     The level of the card. This only pertains to cards from older sets and those of supertype Pokémon.
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        ///     The hit points of the card.
        /// </summary>
        [JsonPropertyName("hp")]
        [JsonNumberHandling(JsonNumberHandling
            .AllowReadingFromString)] // TCGO Api encodes this as a string. -> see https://github.com/PokemonTCG/pokemon-tcg-api/issues/96
        public int? Hitpoints { get; set; }

        /// <summary>
        ///     The energy types for a card, such as Fire, Water, Grass, etc.
        /// </summary>
        public IEnumerable<string> Types { get; set; }

        /// <summary>
        ///     Which Pokémon this card evolves from.
        /// </summary>
        public string EvolvesFrom { get; set; }

        /// <summary>
        ///     Which Pokémon this card evolves to.
        /// </summary>
        /// <remarks>
        ///     Can be multiple, for example, Eeve, which has multiple evolutions.
        /// </remarks>
        public IEnumerable<string> EvolvesTo { get; set; }

        /// <summary>
        ///     Any rules associated with the card. For example, VMAX rules, Mega rules, or various trainer rules.
        /// </summary>
        public IEnumerable<string> Rules { get; set; }

        /// <summary>
        ///     The ancient trait for a given card.
        /// </summary>
        public AncientTrait AncientTrait { get; set; }

        /// <summary>
        ///     One or more abilities for a given card.
        /// </summary>
        public IEnumerable<Ability> Abilities { get; set; }

        /// <summary>
        ///     One or more attacks for a given card.
        /// </summary>
        public IEnumerable<Attack> Attacks { get; set; }

        /// <summary>
        ///     One or more weaknesses for a given card.
        /// </summary>
        public IEnumerable<WeaknessOrResistance> Weakness { get; set; }

        /// <summary>
        ///     One or more resistances for a given card.
        /// </summary>
        public IEnumerable<WeaknessOrResistance> Resistances { get; set; }

        /// <summary>
        ///     A list of costs it takes to retreat and return the card to your bench. Each cost is an energy type, such as Water
        ///     or Fire.
        /// </summary>
        public string RetreatCosts { get; set; }

        /// <summary>
        ///     The converted retreat cost for a card is the count of energy types found within the retreatCost field. For example,
        ///     ["Fire", "Water"] has a converted retreat cost of 2.
        /// </summary>
        public int? ConvertedRetreatCost { get; set; }

        /// <summary>
        ///     The set details embedded into the card.
        /// </summary>
        /// <remarks>
        ///     See the <see cref="Set" /> object for more details.
        /// </remarks>
        public Set Set { get; set; }

        /// <summary>
        ///     The number of the card.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        ///     The artist of the card.
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        ///     The rarity of the card, such as "Common" or "Rare Rainbow".
        /// </summary>
        public string Rarity { get; set; }

        /// <summary>
        ///     The flavor text of the card. This is the text that can be found on some Pokémon cards that is usually italicized
        ///     near the bottom of the card.
        /// </summary>
        public string FlavorText { get; set; }

        /// <summary>
        ///     The national pokedex numbers associated with any Pokémon featured on a given card.
        /// </summary>
        public IEnumerable<int?> NationalPokedexNumbers { get; set; }

        /// <summary>
        ///     The legalities for a given card.
        /// </summary>
        /// <remarks>
        ///     A legality will not be present in the <see cref="Legalities" /> if it is not legal. If it is legal or banned, it
        ///     will be present.
        /// </remarks>
        public Legalities Legalities { get; set; }

        /// <summary>
        ///     The images for a card.
        /// </summary>
        public CardImages Images { get; set; }

        /// <summary>
        ///     The https://www.tcgplayer.com information for a given card.
        /// </summary>
        /// <remarks>
        ///     All prices are in US Dollars.
        /// </remarks>
        /// <remarks>
        ///     See the <see cref="TcgPlayerEntry" /> object for more details.
        /// </remarks>
        public TcgPlayerEntry TcgPlayer { get; set; }

        /// <summary>
        ///     The https://www.cardmarket.com/ information for a given card.
        /// </summary>
        /// <remarks>
        ///     All prices are in Euros.
        /// </remarks>
        /// <remarks>
        ///     See the <see cref="CardmarketEntry" /> object for more details.
        /// </remarks>
        public CardmarketEntry Cardmarket { get; set; }

        public string Id { get; set; }
    }
}