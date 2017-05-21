using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonTcgSdk.Models
{
    public class TypeData
    {
        [JsonProperty("types")]
        public List<string> Types { get; set; }
    }
}
