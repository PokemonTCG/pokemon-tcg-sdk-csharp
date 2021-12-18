using System.Collections.Generic;

namespace PokemonTcgSdkV2.Api.Cards
{
    /// <summary>
    ///     One or more attacks for a given card.
    /// </summary>
    public class Attack
    {
        /// <summary>
        ///     The cost of the attack represented by a list of energy types.
        /// </summary>
        public IEnumerable<string> Costs { get; set; }

        /// <summary>
        ///     The name of the attack.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The text or description associated with the attack.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        ///     The damage amount of the attack.
        /// </summary>
        public string Damage { get; set; }

        /// <summary>
        ///     The total cost of the attack. For example, if it costs 2 fire energy, the converted energy cost is simply 2.
        /// </summary>
        public int? ConvertedEnergyCost { get; set; }
    }
}