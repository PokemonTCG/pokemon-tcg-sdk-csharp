using Newtonsoft.Json;

namespace PokemonTcgSdk.Models
{
    public class SuperType
    {
        [JsonProperty("supertypes")]
        public string[] Types { get; set; }
    }
}
