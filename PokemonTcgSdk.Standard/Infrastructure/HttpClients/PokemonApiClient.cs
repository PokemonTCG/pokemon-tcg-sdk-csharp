namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Base;
    using Features.CacheManager;
    using Newtonsoft.Json;

    public class PokemonApiClient : IDisposable
    {
        private readonly HttpClient _client;
        private readonly Uri _baseUri = new Uri("https://api.pokemontcg.io/v2/");
        private readonly ResourceCacheManager _resourceCache = new ResourceCacheManager();
        private readonly ResourceListCacheManager _resourceListCache = new ResourceListCacheManager();
        public static readonly string ApiKey = "";

        /// <summary>
        /// Default constructor
        /// </summary>
        public PokemonApiClient() : this(ApiKey) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PokemonApiClient"/> with 
        /// a given value for the `User-Agent` header
        /// </summary>
        /// <param name="apiKey">The value for the default `X-Api-Key` header.</param>
        public PokemonApiClient(string apikey)
        {
            _client = new HttpClient() { BaseAddress = _baseUri };
            _client.DefaultRequestHeaders.Add("X-Api-Key", apikey);
        }

        /// <summary>
        /// Constructor with message handler and `Api key` header value.
        /// Without the api key it will work but you will be rate limited. See docs
        /// </summary>
        /// <param name="messageHandler">Message handler implementation</param>
        /// <param name="apiKey">The value for the developers api key.</param>
        public PokemonApiClient(HttpMessageHandler messageHandler, string apiKey = "")
        {
            _client = new HttpClient(messageHandler) { BaseAddress = _baseUri };
            _client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);
        }

        /// <summary>
        /// Construct accepting directly a HttpClient. Useful when used in projects where
        /// IHttpClientFactory is used to create and configure HttpClient instances with different policies.
        /// See https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
        /// </summary>
        /// <param name="httpClient">HttpClient implementation. Should include api key in header else you will be rate limited. See docs</param>
        public PokemonApiClient(HttpClient httpClient)
        {
            _client = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _client.BaseAddress = _baseUri;
        }

        /// <summary>
        /// Close resources
        /// </summary>
        public void Dispose()
        {
            _client.Dispose();
            _resourceCache.Dispose();
            _resourceListCache.Dispose();
        }

        public async Task<T> GetStringResourceAsync<T>() where T : ResourceBase
        {
            string url = GetApiEndpointString<T>();
            return await GetAsync<T>(url, CancellationToken.None);
        }

        /// <summary>
        /// Clears all cached data for both resources and resource lists
        /// </summary>
        public void ClearCache()
        {
            _resourceCache.ClearAll();
            _resourceListCache.ClearAll();
        }

        /// <summary>
        /// Clears the cached data for a specific resource
        /// </summary>
        /// <typeparam name="T">The type of cache</typeparam>
        public void ClearResourceCache<T>()
            where T : ResourceBase
        {
            _resourceCache.Clear<T>();
        }

        /// <summary>
        /// Clears the cached data for all resource types
        /// </summary>
        public void ClearResourceCache()
        {
            _resourceCache.ClearAll();
        }

        /// <summary>
        /// Clears the cached data for all resource lists
        /// </summary>
        public void ClearResourceListCache()
        {
            _resourceListCache.ClearAll();
        }

        /// <summary>
        /// Clears the cached data for a specific resource list
        /// </summary>
        /// <typeparam name="T">The type of cache</typeparam>
        public void ClearResourceListCache<T>()
            where T : ResourceBase
        {
            _resourceListCache.Clear<T>();
        }

        /// <summary>
        /// Gets a single page of unnamed resource data
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <returns>The paged resource object</returns>
        public Task<ApiResourceList<T>> GetApiResourceAsync<T>(CancellationToken cancellationToken = default)
            where T : ApiResource
        {
            string url = GetApiEndpointString<T>();
            return InternalGetApiResourcePageAsync<T>(AddPaginationParamsToUrl(url), cancellationToken);
        }

        /// <summary>
        /// Gets the specified page of unnamed resource data
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="take">The number of cards to return</param>
        /// <param name="skip">Page offset/skip</param>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <returns>The paged resource object</returns>
        public Task<ApiResourceList<T>> GetApiResourceAsync<T>(int take, int skip, CancellationToken cancellationToken = default)
            where T : ApiResource
        {
            string url = GetApiEndpointString<T>();
            return InternalGetApiResourcePageAsync<T>(AddPaginationParamsToUrl(url, take, skip), cancellationToken);
        }

        /// <summary>
        /// Gets the specified page of unnamed resource data
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="filters">Dictionary of filters based on data fields. e.g name=base </param>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <returns>The paged resource object</returns>
        public Task<ApiResourceList<T>> GetApiResourceAsync<T>(IDictionary<string, string> filters, CancellationToken cancellationToken = default)
            where T : ApiResource
        {
            string url = GetApiEndpointString<T>();
            return InternalGetApiResourcePageAsync<T>(AddQueryFilterParamsToUrl(url, filters), cancellationToken);
        }

        /// <summary>
        /// Gets the specified page of unnamed resource data
        /// </summary>
        /// <typeparam name="T">The type of resource</typeparam>
        /// <param name="take">The number of cards to return</param>
        /// <param name="skip">Page offset/skip</param>
        /// <param name="filters">Dictionary of filters based on data fields. e.g name=base </param>
        /// <param name="cancellationToken">Cancellation token for the request; not utilitized if data has been cached</param>
        /// <returns>The paged resource object</returns>
        public Task<ApiResourceList<T>> GetApiResourceAsync<T>(int take , int skip, IDictionary<string, string> filters, CancellationToken cancellationToken = default)
            where T : ApiResource
        {
            string url = GetApiEndpointString<T>();
            return InternalGetApiResourcePageAsync<T>(AddQueryFilterParamsToUrl(url, filters, take, skip), cancellationToken);
        }

        private async Task<ApiResourceList<T>> InternalGetApiResourcePageAsync<T>(string url, CancellationToken cancellationToken)
            where T : ApiResource
        {
            var resources = _resourceListCache.GetApiResourceList<T>(url);
            if (resources == null)
            {
                resources = await GetAsync<ApiResourceList<T>>(url, cancellationToken);
                _resourceListCache.Store(url, resources);
            }
            else
            {
                // we do this as a marker that the cache is used, useful for debugging
                resources.FromCache = true;
            }

            return resources;
        }

        /// <summary>
        /// Handles all outbound API requests to the Pokemon API server and deserializes the response
        /// </summary>
        private async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            using var response = await _client.SendAsync(request, HttpCompletionOption.ResponseContentRead, cancellationToken);

            #if DEBUG
            // For debugging respose pre deserialisation
            var responseStr = response.Content.ReadAsStringAsync().Result;
            #endif

            response.EnsureSuccessStatusCode();
            return DeserializeStream<T>(await response.Content.ReadAsStreamAsync());
        }

        /// <summary>
        /// Handles deserialization of a given stream to a given type
        /// </summary>
        private T DeserializeStream<T>(System.IO.Stream stream)
        {
            using var sr = new System.IO.StreamReader(stream);
            using JsonReader reader = new JsonTextReader(sr);
            var serializer = JsonSerializer.Create();
            return serializer.Deserialize<T>(reader);
        }

        private static string AddPaginationParamsToUrl(string uri, int? pageSize = null, int? page = null)
        {
            var queryParameters = new Dictionary<string, string>();

            // TODO consider to always set the pageSize parameter when not present to the default "20"
            // in order to have a single cached resource list for requests with explicit or implicit default take
            if (pageSize.HasValue)
            {
                queryParameters.Add(nameof(pageSize), pageSize.Value.ToString());
            }

            if (page.HasValue)
            {
                queryParameters.Add(nameof(page), page.Value.ToString());
            }

            return QueryHelpers.AddQueryString(uri, queryParameters);
        }

        private static string AddQueryFilterParamsToUrl(string uri, IDictionary<string, string> filterQuery, int? pageSize = null, int? page = null)
        {
            var queryParameters = new Dictionary<string, string>();

            // TODO consider to always set the pageSize parameter when not present to the default "20"
            // in order to have a single cached resource list for requests with explicit or implicit default take
            if (pageSize.HasValue)
            {
                queryParameters.Add(nameof(pageSize), pageSize.Value.ToString());
            }

            if (page.HasValue)
            {
                queryParameters.Add(nameof(page), page.Value.ToString());
            }

            return QueryHelpers.AddQueryFiltersString(uri, queryParameters, filterQuery);
        }

        private static string GetApiEndpointString<T>()
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty("ApiEndpoint", BindingFlags.Static | BindingFlags.NonPublic);
            return propertyInfo.GetValue(null).ToString();
        }

        private static bool IsApiEndpointCaseSensitive<T>()
        {
            PropertyInfo propertyInfo = typeof(T).GetProperty("IsApiEndpointCaseSensitive", BindingFlags.Static | BindingFlags.NonPublic);
            return propertyInfo == null ? false : (bool)propertyInfo.GetValue(null);
        }
    }
}