using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PokemonTcgSdkV2.Api;

namespace PokemonTcgSdkV2.Client.Responses
{
    public class EnumerableApiResponse<T> : IApiResponse<IEnumerable<T>>,
        IPageAbleApiResponse<EnumerableApiResponse<T>, IEnumerable<T>>
        where T : FetchableApiObject
    {
        private string RequestUri { get; set; }

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
            var requestUri = RequestUri + "&page=" + page;
            return await CurrentApiClient.FetchData<EnumerableApiResponse<T>, IEnumerable<T>>(requestUri);
        }

        public void RemberRequestUri(string requestUri)
        {
            // Remember full Uri without page
            requestUri = Regex.Replace(requestUri, @"page=\d*&?", "");
            RequestUri = requestUri;
        }
    }
}