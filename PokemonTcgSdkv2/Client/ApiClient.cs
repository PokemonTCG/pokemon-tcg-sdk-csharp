using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using PokemonTcgSdkV2.Api;
using PokemonTcgSdkV2.Client.Endpoints;
using PokemonTcgSdkV2.Client.Responses;

namespace PokemonTcgSdkV2.Client
{
    public class ApiClient
    {
        private readonly HttpClient _client;

#if NETCOREAPP3_1
        public ApiClient(string apiKey, SocketsHttpHandler handler) : this(apiKey, new HttpClient(handler))
        {
        }
#endif

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

        public async Task<IApiResponse<T>> FetchData<T>() where T : FetchableApiObject
        {
            var endpoint = EndpointFactory.GetApiEndpoint<T>();
            var responseType = ResponseFactory.GetApiResponse<T>();

            if (endpoint == null) throw new Exception("No endpoint registered.");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
                IgnoreNullValues = true
            };

            var response = await _client.GetFromJsonAsync(endpoint.ApiUri(), responseType, options) as IApiResponse<T>;
            return response;
        }

        public async Task<ApiCardResponse> QueryCards(string query = null, int page = 1)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
                IgnoreNullValues = true
            };

            var cards =
                await _client.GetFromJsonAsync<ApiCardResponse>($"cards?q={query ?? ""}&page={page}", options) ??
                new ApiCardResponse();

            return cards;
        }

        public async Task<ApiSetResponse> QuerySets(string query = null, int page = 1)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
                IgnoreNullValues = true
            };

            var sets =
                await _client.GetFromJsonAsync<ApiSetResponse>($"sets?q={query ?? ""}&page={page}", options) ??
                new ApiSetResponse();

            return sets;
        }
    }
}