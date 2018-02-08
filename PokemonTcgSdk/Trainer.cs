using Newtonsoft.Json;
using PokemonTcgSdk.Models;
using System.Collections.Generic;

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