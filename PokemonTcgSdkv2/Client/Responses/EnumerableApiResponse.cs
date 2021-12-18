using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PokemonTcgSdkV2.Api;

namespace PokemonTcgSdkV2.Client.Responses
{
    /// <summary>
    ///     Enumerable api response of a fetchable api object.
    /// </summary>
    /// <typeparam name="T">Any <see cref="FetchableApiObject" />.</typeparam>
    public class EnumerableApiResponse<T> : IApiResponse<IEnumerable<T>>,
        IPageAbleApiResponse<EnumerableApiResponse<T>, IEnumerable<T>>
        where T : FetchableApiObject
    {
        private string RequestUri { get; set; }

        /// <summary>
        ///     Total pages of the result.
        /// </summary>
        public int TotalPages => (int) Math.Ceiling((decimal) TotalCount / PageSize);

        /// <summary>
        ///     Enumerable with the date from current page.
        /// </summary>
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        ///     Current instance of the used <see cref="ApiClient" /> to perform the paging requests.
        /// </summary>
        public ApiClient CurrentApiClient { get; set; }

        /// <summary>
        ///     Current page of results.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        ///     Currently used page size.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        ///     Amount of data entries on the current page.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        ///     Total amount of results among all pages.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        ///     Fetches the next page of the current query.
        /// </summary>
        /// <returns>The next page of the current query.</returns>
        public async Task<EnumerableApiResponse<T>> FetchNextPage()
        {
            return await FetchPage(Page + 1);
        }

        /// <summary>
        ///     Fetches a specific page of the current query.
        /// </summary>
        /// <param name="page">Page to fetch.</param>
        /// <returns>Specified page of the current query.</returns>
        public async Task<EnumerableApiResponse<T>> FetchPage(int page)
        {
            var requestUri = RequestUri + "&page=" + page;
            return await CurrentApiClient.FetchData<EnumerableApiResponse<T>, IEnumerable<T>>(requestUri);
        }

        /// <summary>
        ///     Remembers the current query.
        /// </summary>
        /// <param name="requestUri"></param>
        public void RememberRequestUri(string requestUri)
        {
            // Remember full Uri without page
            requestUri = Regex.Replace(requestUri, @"page=\d*&?", "");
            RequestUri = requestUri;
        }
    }
}