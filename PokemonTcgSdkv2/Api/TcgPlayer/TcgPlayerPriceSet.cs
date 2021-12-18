using System.Text.Json.Serialization;

namespace PokemonTcgSdkV2.Api.TcgPlayer
{
    /// <summary>
    ///     Price information for the card.
    /// </summary>
    /// <remarks>
    ///     All prices are in US Dollars.
    /// </remarks>
    public class TcgPlayerPriceSet
    {
        /// <summary>
        ///     The price information for a normal card type.
        /// </summary>
        /// <remarks>
        ///     All prices are in US Dollars.
        /// </remarks>
        public TcgPlayerPrice Normal { get; set; }

        /// <summary>
        ///     The price information for a holo foil card type.
        /// </summary>
        /// <remarks>
        ///     All prices are in US Dollars.
        /// </remarks>
        public TcgPlayerPrice HoloFoil { get; set; }

        /// <summary>
        ///     The price information for a reverse hholos foil card type.
        /// </summary>
        /// <remarks>
        ///     All prices are in US Dollars.
        /// </remarks>
        public TcgPlayerPrice ReverseHolofoil { get; set; }

        /// <summary>
        ///     The price information for an 1st edition holo foil card type.
        /// </summary>
        /// <remarks>
        ///     All prices are in US Dollars.
        /// </remarks>
        [JsonPropertyName("1stEditionHolofoil")]
        public TcgPlayerPrice FirstEditionHolofoil { get; set; }

        /// <summary>
        ///     The price information for an 1st edition normal card type.
        /// </summary>
        /// <remarks>
        ///     All prices are in US Dollars.
        /// </remarks>
        [JsonPropertyName("1stEditionNormal")]
        public TcgPlayerPrice FirstEditionNormal { get; set; }
    }
}