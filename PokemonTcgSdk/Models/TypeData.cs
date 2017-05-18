using Newtonsoft.Json;

namespace PokemonTcgSdk.Models
{
    public class TypeData
    {
        [JsonProperty("types")]
        public string[] Types { get; set; }
    }
}
