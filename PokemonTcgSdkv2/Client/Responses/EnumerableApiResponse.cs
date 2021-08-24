using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonTcgSdkV2.Api;

namespace PokemonTcgSdkV2.Client.Responses
{
    public class EnumerableApiResponse<T> : IApiResponse<IEnumerable<T>>,
        IPageAbleApiResponse<EnumerableApiResponse<T>, IEnumerable<T>>
        where T : FetchableApiObject
    {
        public int TotalPages => (int) Math.Ceiling((decimal) TotalCount / PageSize);

        public IEnumerable<T> Data { get; set; }
        public ApiClient CurrentApiClient { get; set; }
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int Count { get; set; }

        public int TotalCount { get; set; }

        public async Task<EnumerableApiResponse<T>> FetchNextPage()
        {
            return await FetchPage(Page + 1);
        }

        public async Task<EnumerableApiResponse<T>> FetchPage(int page)
        {
            return await CurrentApiClient.FetchData<T>(null, page);
        }
    }
}