using System.Collections.Generic;
using PokemonTcgSdkV2.Api;

namespace PokemonTcgSdkV2.Client.Responses
{
    public interface IApiResponse<T> where T : FetchableApiObject
    {
        IEnumerable<T> Data { get; set; }

        int Page { get; set; }

        int PageSize { get; set; }

        int Count { get; set; }

        int TotalCount { get; set; }
    }
}