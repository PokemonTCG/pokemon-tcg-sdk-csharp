using System.Collections.Generic;
using System.Text.Json.Serialization;
using PokemonTcgSdkV2.Api.Sets;

namespace PokemonTcgSdkV2.Client.Responses
{
    public class ApiSetResponse : IApiResponse<Set>
    {
        [JsonPropertyName("data")] public IEnumerable<Set> Sets { get; set; }
        public IEnumerable<Set> Data { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
    }
}