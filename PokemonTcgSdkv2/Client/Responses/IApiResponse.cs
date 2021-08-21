using System.Collections.Generic;
using System.Text.Json.Serialization;
using PokemonTcgSdkV2.Api;

namespace PokemonTcgSdkV2.Client.Responses
{
    public interface IApiResponse<T> where T : FetchableApiObject
    {
        [JsonPropertyName("data")] IEnumerable<T> Data { get; set; }

        int Page { get; set; }

        int PageSize { get; set; }

        int Count { get; set; }

        int TotalCount { get; set; }
    }
}