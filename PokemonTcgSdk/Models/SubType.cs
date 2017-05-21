using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonTcgSdk.Models
{
    public class SubType
    {
        [JsonProperty("subtypes")]
        public List<string> Types { get; set; }
    }
}
