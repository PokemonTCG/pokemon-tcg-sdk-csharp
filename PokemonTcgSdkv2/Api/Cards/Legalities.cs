namespace PokemonTcgSdkV2.Api.Cards
{
    /// <summary>
    ///     The legalities for a given card.
    /// </summary>
    /// <remarks>
    ///     A legality will not be present in the <see cref="Legalities" /> if it is not legal. If it is legal or banned, it
    ///     will be present.
    /// </remarks>
    public class Legalities
    {
        /// <summary>
        ///     The legality ruling for Standard. Can be either Legal, Banned, or not present.
        /// </summary>
        public string Standard { get; set; }

        /// <summary>
        ///     The legality ruling for Expanded. Can be either Legal, Banned, or not present.
        /// </summary>
        public string Expanded { get; set; }

        /// <summary>
        ///     The legality ruling for Unlimited. Can be either Legal, Banned, or not present.
        /// </summary>
        public string Unlimited { get; set; }
    }
}