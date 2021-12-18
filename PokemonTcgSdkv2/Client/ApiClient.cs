using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using PokemonTcgSdkV2.Api;
using PokemonTcgSdkV2.Client.Endpoints;
using PokemonTcgSdkV2.Client.Responses;
using PokemonTcgSdkV2.Utils.Query;

namespace PokemonTcgSdkV2.Client
{
    /// <summary>
    ///     The client implementation to communicate with the web api.
    /// </summary>
    public class ApiClient
    {
        private readonly HttpClient _client;

#if NETCOREAPP3_1
        /// <summary>
        ///     Creates a new <see cref="ApiClient" /> with a given api key and socket handler.
        /// </summary>
        /// <param name="apiKey">Api key to use.</param>
        /// <param name="handler">Custom socket handler to use.</param>
        /// <remarks>Usage without <paramref name="apiKey" /> is allowed.</remarks>
        public ApiClient(string apiKey, SocketsHttpHandler handler) : this(apiKey, new HttpClient(handler))
        {
        }
#endif

        /// <summary>
        ///     Creates a new <see cref="ApiClient" /> with a given api key and socket handler.
        /// </summary>
        /// <param name="apiKey">Api key to use.</param>
        /// <remarks>Usage without <paramref name="apiKey" /> is allowed.</remarks>
        public ApiClient(string apiKey) : this(apiKey, new HttpClient())
        {
        }

        private ApiClient(string apiKey, HttpClient client)
        {
            _client = client;

            _client.BaseAddress = new Uri("https://api.pokemontcg.io/v2/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(
                new ProductHeaderValue("PokemonTcgApi", GetType().Assembly.GetName().Version?.ToString())));
            _client.DefaultRequestHeaders.Add("X-Api-Key", apiKey ?? "");
        }

        /// <summary>
        ///     Sends a request to the web api and fetches data.
        /// </summary>
        /// <typeparam name="TResponseType">Response type to build as return type.</typeparam>
        /// <typeparam name="TResponseGeneric">
        ///     Generic <see cref="FetchableApiObject" /> of the
        ///     <typeparamref name="TResponseType" />.
        /// </typeparam>
        /// <param name="requestUri"></param>
        /// <returns>Api result of specified typings for specified request.</returns>
        public async Task<TResponseType>
            FetchData<TResponseType, TResponseGeneric>(string requestUri)
            where TResponseType : IApiResponse<TResponseGeneric>, new()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
                IgnoreNullValues = true
            };

            var response = await _client.GetFromJsonAsync<TResponseType>(requestUri, options);

            if (response is IPageAbleApiResponse<TResponseType, TResponseGeneric> pageAbleApiResponse)
            {
                pageAbleApiResponse.CurrentApiClient = this;
                pageAbleApiResponse.RemberRequestUri(requestUri);
            }

            return response;
        }

        /// <summary>
        ///     Sends a request to the web api and fetches data for a given query.
        /// </summary>
        /// <typeparam name="T">Type of object to fetch.</typeparam>
        /// <param name="query">Search query.</param>
        /// <param name="page">Page to fetch.</param>
        /// <returns>Pageable api response for given search query.</returns>
        public async Task<EnumerableApiResponse<T>> FetchData<T>(QueryBuilder query = null, int page = 1)
            where T : FetchableApiObject
        {
            var endpoint = EndpointFactory.GetApiEndpoint<T>();

            var queryStr = "";
            if (query != null) queryStr = query.BuildQuery();

            return await FetchData<EnumerableApiResponse<T>, IEnumerable<T>>(
                $"{endpoint.ApiUri()}?page={page}&q={queryStr}");
        }

        /// <summary>
        ///     Sends a request to the web api and fetches data for a given Id.
        /// </summary>
        /// <typeparam name="T">Type of object to fetch.</typeparam>
        /// <param name="id">Id to fetch.</param>
        /// <returns>Singel api response with the result for the given Id search value.</returns>
        public async Task<SingleApiResponse<T>> FetchById<T>(string id) where T : FetchableApiObject, IApiObjectWithId
        {
            var endpoint = EndpointFactory.GetApiEndpoint<T>();

            return await FetchData<SingleApiResponse<T>, T>($"{endpoint.ApiUri()}/{id}");
        }
    }
}