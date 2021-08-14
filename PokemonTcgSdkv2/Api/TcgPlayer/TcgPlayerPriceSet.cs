using System.Text.Json.Serialization;

namespace PokemonTcgSdkV2.Api.TcgPlayer
{
    public class TcgPlayerPriceSet
    {
        public TcgPlayerPrice Normal { get; set; }

        public TcgPlayerPrice HoloFoil { get; set; }

        public TcgPlayerPrice ReverseHolofoil { get; set; }

        [JsonPropertyName("1stEditionHolofoil")]
        public TcgPlayerPrice FirstEditionHolofoil { get; set; }

        [JsonPropertyName("1stEditionNormal")] public TcgPlayerPrice FirstEditionNormal { get; set; }
    }
}