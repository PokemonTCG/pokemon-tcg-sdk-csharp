using Newtonsoft.Json;
using PokemonTcgSdk.Models;
using System.Collections.Generic;

namespace PokemonTcgSdk
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Energy
    {
        [JsonProperty("cards")]
        public List<EnergyCard> Cards { get; set; }

        [JsonProperty("card")]
        public EnergyCard Card { get; set; }

        public List<string> Errors { get; set; }
    }
}