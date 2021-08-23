using System.Collections.Generic;
using PokemonTcgSdkV2.Api;

namespace PokemonTcgSdkV2.Client.Responses
{
    public class IterableApiResponse<T> : IApiResponse<IEnumerable<T>> where T : FetchableApiObject
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int Count { get; set; }

        public int TotalCount { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}