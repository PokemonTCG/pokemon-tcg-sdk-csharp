using System.Text.Json.Serialization;

namespace PokemonTcgSdk.Api.Cards
{
    public class CardImages
    {
        [JsonPropertyName("small")] public string SmallImageUrl { get; set; }

        [JsonPropertyName("large")] public string LargeImageUrl { get; set; }
    }
}