namespace PokemonTcgSdkV2.Api.Cards
{
    /// <summary>
    ///     Weakness or Resistance for a given card.
    /// </summary>
    public class WeaknessOrResistance
    {
        /// <summary>
        ///     The type of weakness or resistance, such as Fire or Water.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        ///     The value of the weakness or resistance.
        /// </summary>
        public string Value { get; set; }
    }
}