using Newtonsoft.Json;

namespace PokemonTcgSdk.Models
{
    public class SubType
    {
        [JsonProperty("subtypes")]
        public string[] Types { get; set; }
    }
}
