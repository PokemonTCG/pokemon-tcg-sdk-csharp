using Newtonsoft.Json;
using System.Collections.Generic;

namespace PokemonTcgSdk.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class SetData
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("ptcgoCode")]
        public string PtcgoCode { get; set; }

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

        public List<string> Errors { get; set; }
    }
}
