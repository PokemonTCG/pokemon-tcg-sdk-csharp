using System.Collections.Generic;
using System.Text.Json.Serialization;
using PokemonTcgSdkV2.Api.Sets;

namespace PokemonTcgSdkV2.Client
{
    public class ApiSetResponse : ApiResponse
    {
        [JsonPropertyName("data")] public IEnumerable<Set> Sets { get; set; }
    }
}