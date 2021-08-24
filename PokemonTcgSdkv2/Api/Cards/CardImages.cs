using System.Text.Json.Serialization;

namespace PokemonTcgSdkV2.Api.Cards
{
    public class CardImages
    {
        /// <summary>
        ///     A smaller, lower-res image for a card.
        /// </summary>
        /// <remarks>
        ///     This is a URL.
        /// </remarks>
        [JsonPropertyName("small")]
        public string SmallImageUrl { get; set; }

        /// <summary>
        ///     A larger, higher-res image for a card.
        /// </summary>
        /// <remarks>
        ///     This is a URL.
        /// </remarks>
        [JsonPropertyName("large")]
        public string LargeImageUrl { get; set; }
    }
}