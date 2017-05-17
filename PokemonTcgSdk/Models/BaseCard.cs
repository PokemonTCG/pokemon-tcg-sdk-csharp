using Newtonsoft.Json;

namespace PokemonTcgSdk.Models
{
    public class BaseCard
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("imageUrlHiRes")]
        public string ImageUrlHiRes { get; set; }

        [JsonProperty("subType")]
        public string SubType { get; set; }

        [JsonProperty("superType")]
        public string SuperType { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        [JsonProperty("rarity")]
        public string Rarity { get; set; }

        [JsonProperty("series")]
        public string Series { get; set; }

        [JsonProperty("set")]
        public string Set { get; set; }

        [JsonProperty("setCode")]
        public string SetCode { get; set; }
    }
}