using System.Text.Json.Serialization;

namespace PokemonTcgSdkV2.Api.Cards
{
    public class CardImages
    {
        [JsonPropertyName("small")] public string SmallImageUrl { get; set; }

        [JsonPropertyName("large")] public string LargeImageUrl { get; set; }
    }
}