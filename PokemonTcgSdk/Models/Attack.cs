using System.Collections.Generic;

namespace PokemonTcgSdk.Models
{
    public class Attack
    {
        public List<string> Cost { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string Damage { get; set; }
        public int ConvertedEnergyCost { get; set; }
    }
}