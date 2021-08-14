using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PokemonTcgSdk.Client
{
    public class ApiClient
    {
        private readonly HttpClient _client = new HttpClient();

        public ApiClient(string? apiKey)
        {
            _client.BaseAddress = new Uri("https://api.pokemontcg.io/v2/");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(
                new ProductHeaderValue("PokemonTcgApi", GetType().Assembly.GetName().Version?.ToString())));
            _client.DefaultRequestHeaders.Add("X-Api-Key", apiKey ?? "");
        }
    }
}