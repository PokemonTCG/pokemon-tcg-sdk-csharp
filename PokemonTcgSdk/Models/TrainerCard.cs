using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonTcgSdk.Models
{
    public class TrainerCard : BaseCard
    {
        [JsonProperty("text")]
        public List<string> Text { get; set; }
    }
}