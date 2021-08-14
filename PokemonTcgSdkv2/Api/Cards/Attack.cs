using System.Collections.Generic;

namespace PokemonTcgSdk.Api.Cards
{
    public class Attack
    {
        public IEnumerable<string> Costs { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public string Damage { get; set; }

        public int ConvertedEnergyCost { get; set; }
    }
}