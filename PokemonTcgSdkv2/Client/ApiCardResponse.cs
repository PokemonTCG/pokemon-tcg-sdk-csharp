using System.Collections.Generic;
using System.Text.Json.Serialization;
using PokemonTcgSdkV2.Api.Cards;

namespace PokemonTcgSdkV2.Client
{
    public class ApiCardResponse : ApiResponse
    {
        [JsonPropertyName("data")] public IEnumerable<Card> Cards { get; set; }
    }
}