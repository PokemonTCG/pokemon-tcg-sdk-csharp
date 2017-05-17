using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTcgSdk.Models
{
    public class PokemonCardObject
    {
        [JsonProperty("card")]
        public PokemonCard PokemonCard { get; set; }

        [JsonProperty("cards")]
        public List<PokemonCard> PokemonCards { get; set; }

        [JsonProperty("cards")]
        public List<TrainerCard> TrainerCards { get; set; }
    }
}
