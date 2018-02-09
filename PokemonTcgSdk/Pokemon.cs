using Newtonsoft.Json;
using PokemonTcgSdk.Models;
using System.Collections.Generic;

namespace PokemonTcgSdk
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Pokemon
    {
        [JsonProperty("cards")]
        public List<PokemonCard> Cards { get; set; }

        [JsonProperty("card")]
        public PokemonCard Card { get; set; }

        public List<string> Errors { get; set; }
    }
}