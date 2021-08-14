using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace PokemonTcgSdkV2.Client
{
    public class ApiClient
    {
        private readonly HttpClient _client = new HttpClient();

        public ApiClient(string apiKey)
        {
            _client.BaseAddress = new Uri("https://api.pokemontcg.io/v2/");
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(
                new ProductHeaderValue("PokemonTcgApi", GetType().Assembly.GetName().Version?.ToString())));
            _client.DefaultRequestHeaders.Add("X-Api-Key", apiKey ?? "");
        }

        public async Task<ApiCardResponse> QueryCards(string query, int page = 1)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true,
                IgnoreNullValues = true
            };

            var cards = await _client.GetFromJsonAsync<ApiCardResponse>($"cards?q={query}&page={page}", options) ??
                        new ApiCardResponse();

            return cards;
        }
    }
}