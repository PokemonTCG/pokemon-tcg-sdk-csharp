using System.Collections.Generic;
using PokemonTcgSdk.Models;
using Newtonsoft.Json;

namespace PokemonTcgSdk
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Trainer
    {
        [JsonProperty("cards")]
        public List<TrainerCard> Cards { get; set; }

        [JsonProperty("card")]
        public TrainerCard Card { get; set; }

        public List<string> Errors { get; set; }
    }
}
