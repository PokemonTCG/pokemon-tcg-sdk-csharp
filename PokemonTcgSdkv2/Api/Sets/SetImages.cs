using System.Text.Json.Serialization;

namespace PokemonTcgSdkV2.Api.Sets
{
    /// <summary>
    ///     Any images associated with the set, such as symbol and logo.
    /// </summary>
    public class SetImages
    {
        /// <summary>
        ///     The url to the symbol image.
        /// </summary>
        [JsonPropertyName("symbol")]
        public string SymbolImageUrl { get; set; }

        /// <summary>
        ///     The url to the logo image.
        /// </summary>
        [JsonPropertyName("logo")]
        public string LogoImageUrl { get; set; }
    }
}