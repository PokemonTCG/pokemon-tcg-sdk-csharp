using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTcgSdk.Models
{
    public class TrainerCardObject
    {
        [JsonProperty("card")]
        public TrainerCard PokemonCard { get; set; }

        [JsonProperty("cards")]
        public List<TrainerCard> PokemonCards { get; set; }
    }
}
