using System.Threading.Tasks;

namespace PokemonTcgSdkV2.Client.Responses
{
    /// <summary>
    ///     Interface for a pageable api response.
    /// </summary>
    /// <typeparam name="TResponseType"></typeparam>
    /// <typeparam name="TResponseGeneric"></typeparam>
    public interface IPageAbleApiResponse<TResponseType, TResponseGeneric>
        where TResponseType : IApiResponse<TResponseGeneric>
    {
        /// <summary>
        ///     Current instance of the used <see cref="ApiClient" /> to perform the paging requests.
        /// </summary>
        ApiClient CurrentApiClient { get; set; }

        /// <summary>
        ///     Current page of results.
        /// </summary>
        int Page { get; set; }

        /// <summary>
        ///     Currently used page size.
        /// </summary>
        int PageSize { get; set; }

        /// <summary>
        ///     Amount of data entries on the current page.
        /// </summary>
        int Count { get; set; }

        /// <summary>
        ///     Total amount of results among all pages.
        /// </summary>
        int TotalCount { get; set; }

        /// <summary>
        ///     Remembers the current query.
        /// </summary>
        /// <param name="requestUri"></param>
        void RemberRequestUri(string requestUri);

        /// <summary>
        ///     Fetches the next page of the current query.
        /// </summary>
        /// <returns>The next page of the current query.</returns>
        Task<TResponseType> FetchNextPage();

        /// <summary>
        ///     Fetches a specific page of the current query.
        /// </summary>
        /// <param name="page">Page to fetch.</param>
        /// <returns>Specified page of the current query.</returns>
        Task<TResponseType> FetchPage(int page);
    }
}