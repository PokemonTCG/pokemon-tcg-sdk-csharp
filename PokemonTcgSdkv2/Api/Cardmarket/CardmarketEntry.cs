namespace PokemonTcgSdkV2.Api.Cardmarket
{
    /// <summary>
    ///     The https://www.cardmarket.com/ information for a given card.
    /// </summary>
    /// <remarks>
    ///     All prices are in Euros.
    /// </remarks>
    public class CardmarketEntry
    {
        /// <summary>
        ///     The URL to the cardmarket store page to purchase this card.
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
        ///     All prices are in Euros.
        /// </remarks>
        public CardmarketPrice Prices { get; set; }
    }
}