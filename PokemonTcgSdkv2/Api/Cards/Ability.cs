namespace PokemonTcgSdkV2.Api.Cards
{
    /// <summary>
    ///     One or more abilities for a given card.
    /// </summary>
    public class Ability
    {
        /// <summary>
        ///     The name of the ability.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The text value of the ability.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     The type of the ability, such as Ability or Pokémon-Power.
        /// </summary>
        public string Type { get; set; }
    }
}