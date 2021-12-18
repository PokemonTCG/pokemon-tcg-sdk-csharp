namespace PokemonTcgSdkV2.Api.TcgPlayer
{
    /// <summary>
    ///     The https://www.tcgplayer.com information for a given card.
    /// </summary>
    /// <remarks>
    ///     All prices are in US Dollars.
    /// </remarks>
    public class TcgPlayerEntry
    {
        /// <summary>
        ///     The URL to the TCGPlayer store page to purchase this card.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        ///     A date that the price was last updated. In the format of YYYY/MM/DD
        /// </summary>
        public string UpdatedAt { get; set; }

        /// <summary>
        ///     Price information for the card.
        /// </summary>
        /// <remarks>
        ///     All prices are in US Dollars.
        /// </remarks>
        public TcgPlayerPriceSet Prices { get; set; }
    }
}