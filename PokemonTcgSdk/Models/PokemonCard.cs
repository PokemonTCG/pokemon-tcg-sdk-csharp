using System.Collections.Generic;
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

        [JsonProperty("types")]
        public List<string> Types { get; set; }

        [JsonProperty("attacks")]
        public List<Attack> Attacks { get; set; }

        [JsonProperty("weaknesses")]
        public List<Weakness> Weaknesses { get; set; }
    }
}