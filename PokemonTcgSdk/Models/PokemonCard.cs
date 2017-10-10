using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace PokemonTcgSdk.Models
{
    public class PokemonCard : BaseCard
    {
        [JsonProperty("nationalPokedexNumber")]
        public int NationalPokedexNumber { get; set; }

        [JsonProperty("hp")]
        public string Hp { get; set; }

        [JsonProperty("retreatCost")]
        public List<string> RetreatCost { get; set; }

        [JsonProperty("ability")]
        public Ability Ability { get; set; }

        [JsonProperty("ancientTrait")]
        public AncientTrait AncientTrait { get; set; }

        [JsonProperty("types")]
        public List<string> Types { get; set; }

        [JsonProperty("attacks")]
        public List<Attack> Attacks { get; set; }

        [JsonProperty("weaknesses")]
        public List<Weakness> Weaknesses { get; set; }

        [JsonProperty("resistances")]
        public List<Weakness> Resistances { get; set; }

        [DefaultValue("-")]
        [JsonProperty("evolvesFrom", DefaultValueHandling = DefaultValueHandling.Populate)]
        public string EvolvesFrom { get; set; }
    }
}