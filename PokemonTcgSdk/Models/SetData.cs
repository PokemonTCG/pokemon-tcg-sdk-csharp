using Newtonsoft.Json;

namespace PokemonTcgSdk.Models
{
    public class SetData
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("series")]
        public string Series { get; set; }

        [JsonProperty("totalCards")]
        public int TotalCards { get; set; }

        [JsonProperty("standardLegal")]
        public bool StandardLegal { get; set; }

        [JsonProperty("expandedLegal")]
        public bool ExpandedLegal { get; set; }

        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }
    }
}
