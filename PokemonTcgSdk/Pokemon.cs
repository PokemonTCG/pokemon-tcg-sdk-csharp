using System.Collections.Generic;
using PokemonTcgSdk.Models;
using Newtonsoft.Json;

namespace PokemonTcgSdk
{
    public class Pokemon
    {
        [JsonProperty("cards")]
        public List<PokemonCard> Cards { get; set; }

        [JsonProperty("card")]
        public PokemonCard Card { get; set; }
    }
}
