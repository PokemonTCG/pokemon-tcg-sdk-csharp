using System.Collections.Generic;
using PokemonTcgSdkV2.Api.Sets;

namespace PokemonTcgSdkV2.Client.Responses
{
    public class ApiSetResponse : IApiResponse<Set>
    {
        public IEnumerable<Set> Data { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
    }
}