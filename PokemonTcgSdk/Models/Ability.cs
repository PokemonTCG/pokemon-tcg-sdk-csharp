using Newtonsoft.Json;

namespace PokemonTcgSdk.Models
{
    public class Ability
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
