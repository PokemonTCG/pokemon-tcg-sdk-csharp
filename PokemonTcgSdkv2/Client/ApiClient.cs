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

        public async Task<TResponseType>
            FetchData<TResponseType, TResponseGeneric>(string requestPath)
            where TResponseType : IApiResponse<TResponseGeneric>, new()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
                IgnoreNullValues = true
            };

            var response = await _client.GetFromJsonAsync<TResponseType>(requestPath, options);
            return response;
        }

        public async Task<EnumerableApiResponse<T>> FetchData<T>() where T : FetchableApiObject
        {
            var endpoint = EndpointFactory.GetApiEndpoint<T>();

            if (endpoint == null) throw new Exception("No endpoint registered.");

            return await FetchData<EnumerableApiResponse<T>, IEnumerable<T>>(endpoint.ApiUri());
        }

        public async Task<SingleApiResponse<T>> FetchById<T>(string id) where T : FetchableApiObject, IApiObjectWithId
        {
            var endpoint = EndpointFactory.GetApiEndpoint<T>();

            if (endpoint == null) throw new Exception("No endpoint registered.");

            return await FetchData<SingleApiResponse<T>, T>($"{endpoint.ApiUri()}/{id}");
        }
    }
}