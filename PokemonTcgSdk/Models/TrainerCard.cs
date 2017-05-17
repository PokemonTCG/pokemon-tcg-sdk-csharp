using System.Collections.Generic;
using Newtonsoft.Json;

namespace PokemonTcgSdk.Models
{
    public class TrainerCard : BaseCard
    {
        [JsonProperty("text")]
        public List<string> Text { get; set; }
    }
}