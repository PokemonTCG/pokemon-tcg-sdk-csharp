using System.Collections.Generic;
using PokemonTcgSdkV2.Api.Cards;

namespace PokemonTcgSdkV2.Client.Responses
{
    public class ApiCardResponse : IApiResponse<Card>
    {
        public IEnumerable<Card> Data { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
    }
}