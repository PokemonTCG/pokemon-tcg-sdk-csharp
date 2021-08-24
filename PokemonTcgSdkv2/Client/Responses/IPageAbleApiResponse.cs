using System.Threading.Tasks;

namespace PokemonTcgSdkV2.Client.Responses
{
    public interface IPageAbleApiResponse<TResponseType, TResponseGeneric>
        where TResponseType : IApiResponse<TResponseGeneric>
    {
        ApiClient CurrentApiClient { get; set; }

        int Page { get; set; }

        int PageSize { get; set; }

        int Count { get; set; }

        int TotalCount { get; set; }

        void RemberRequestUri(string requestUri);

        Task<TResponseType> FetchNextPage();

        Task<TResponseType> FetchPage(int page);
    }
}