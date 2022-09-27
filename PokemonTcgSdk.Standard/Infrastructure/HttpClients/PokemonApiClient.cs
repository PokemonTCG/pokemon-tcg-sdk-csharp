namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Extensions;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using PokemonTcgSdk.Standard.Infrastructure.Common;
    using PokemonTcgSdk.Standard.Infrastructure.HttpClients.Set;

    public class PokemonApiClient
    {
        private HttpClient _client;

        private readonly IHttpClientFactory _clientFactory;

        private readonly object _clientLock = new object();

        private readonly ServicesProjectOptions _options;

        public PokemonApiClient(IHttpClientFactory clientFactory, IOptions<ServicesProjectOptions> options)
        {
            _clientFactory = clientFactory;
            _options = options.Value;
            _client = GetClient();
        }

        private HttpClient GetClient()
        {
            if (_client == null)
            {
                lock (_clientLock)
                {
                    if (_client == null)
                    {
                        _client = _clientFactory.CreateClient();
                        _client.BaseAddress = new Uri("https://api.pokemontcg.io/v2/");
                        _client.DefaultRequestHeaders.Add("Accept", "*/*");
                        _client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                        _client.DefaultRequestHeaders.Add("X-Api-Key", _options.ApiKey);
                        _client.Timeout = TimeSpan.FromMinutes(10);
                    }
                }
            }

            return _client;
        }


        public async Task<Attempt<SetResponse>> GetSets()
        {
            var sets = await AttemptGet<SetResponse>($"/sets/");
            return sets;
        }

        private async Task<Attempt<TResponse>> AttemptGet<TResponse>(string relativeUrl)
        {
            return await AttemptAction<TResponse, object>(async () => await SendSync(HttpMethod.Get, relativeUrl));
        }

        private async Task<Attempt<TResponse>> AttemptPost<TResponse, TRequest>(string relativeUrl, TRequest value, Guid? overrideSessionToken = null, bool logPayload = true)
        {
            return await AttemptAction<TResponse, TRequest>(async () => await SendSync(HttpMethod.Post, relativeUrl,
                GetJsonContent(value), overrideSessionToken, logPayload));
        }

        private async Task<Attempt<TResponse>> AttemptAction<TResponse, TRequest>(Func<Task<HttpResponseMessage>> clientRequest)
        {
            var requestUrl = string.Empty;
            try
            {
                var result = await clientRequest.Invoke();
                var content = await result.Content.ReadAsStringAsync();
                requestUrl = result.RequestMessage?.RequestUri?.ToString();

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<TResponse>(content, JsonSettings());
                    return Attempt<TResponse>.Succeed(response);
                }

                var errorMessage = LogResponse(content, result, requestUrl);

                if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    return Attempt<TResponse>.Fail(new NotFoundError(errorMessage));
                }

                if (result.StatusCode == HttpStatusCode.Forbidden)
                {
                    return Attempt<TResponse>.Fail(new ForbiddenError(errorMessage));
                }

                return Attempt<TResponse>.Fail(new Error(errorMessage));
            }
            catch (Exception ex)
            {
                return Attempt<TResponse>.Fail($"Error connecting to API {requestUrl}", ex);
            }
        }

        private async Task<HttpResponseMessage> SendSync(HttpMethod method, string relativeUrl, HttpContent content = null, Guid? overrideSessionToken = null, bool logPayload = true)
        {
            var requestMessage = new HttpRequestMessage(method, relativeUrl);

            if (content != null)
            {
                requestMessage.Content = content;
            }

            var response = await GetClient().SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
            return response;
        }

        private StringContent GetJsonContent<TRequest>(TRequest content)
        {
            var json = JsonConvert.SerializeObject(content, JsonSettings());
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            return stringContent;
        }

        public static JsonSerializerSettings JsonSettings()
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            serializerSettings.Converters.Add(new IsoDateTimeConverter());
            serializerSettings.Converters.Add(new StringEnumConverter());
            return serializerSettings;
        }

        private string LogResponse(string responseContent, HttpResponseMessage result, string requestUrl)
        {
            if (result.Content.Headers.ContentType?.MediaType == "application/json")
            {
                responseContent = JToken.Parse(responseContent).ToString(Formatting.Indented);
            }

            // If we add in logging
            var message = $"{Environment.NewLine} *** Api Response *** {Environment.NewLine}" +
                          $"Requested Url: {requestUrl} ({result.RequestMessage?.Method}) {Environment.NewLine}" +
                          $"Status code: {(int)result.StatusCode} {Environment.NewLine}" +
                          $"Reason: {result.ReasonPhrase} {Environment.NewLine}" +
                          $"Content:{Environment.NewLine}{responseContent}{Environment.NewLine}";


            return $"{(int)result.StatusCode}) {result.ReasonPhrase}";
        }
    }
}