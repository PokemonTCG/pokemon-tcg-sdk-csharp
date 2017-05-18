using System.Collections.Generic;
using PokemonTcgSdk.Models;
using Newtonsoft.Json;

namespace PokemonTcgSdk
{
    public class Trainer
    {
        [JsonProperty("cards")]
        public List<TrainerCard> Cards { get; set; }

        [JsonProperty("card")]
        public TrainerCard Card { get; set; }
    }
}
