namespace PokemonTcgSdkV2.Api.TcgPlayer
{
    /// <summary>
    ///     The price information for card.
    /// </summary>
    /// <remarks>
    ///     All prices are in US Dollars.
    /// </remarks>
    public class TcgPlayerPrice
    {
        /// <summary>
        ///     The low price of the card.
        /// </summary>
        public decimal? Low { get; set; }

        /// <summary>
        ///     The mid price of the card.
        /// </summary>
        public decimal? Mid { get; set; }

        /// <summary>
        ///     The high price of the card.
        /// </summary>
        public decimal? High { get; set; }

        /// <summary>
        ///     The market value of the card. This is usually the best representation of what people are willing to pay.
        /// </summary>
        public decimal? Market { get; set; }

        /// <summary>
        ///     The direct low price of the card.
        /// </summary>
        public decimal? DirectLow { get; set; }
    }
}