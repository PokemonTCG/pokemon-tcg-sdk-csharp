using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonTcgSdk.Models
{
    public class SuperType
    {
        [JsonProperty("supertypes")]
        public List<string> Types { get; set; }
    }
}
