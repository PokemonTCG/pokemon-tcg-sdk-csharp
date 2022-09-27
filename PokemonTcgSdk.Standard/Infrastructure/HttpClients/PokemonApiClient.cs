namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    using Newtonsoft.Json;
    using PokemonTcgSdk.Standard.Infrastructure.Common;
    using Set;

    public class PokemonApiClient
    {
        private readonly HttpClient _client;

        private readonly object _clientLock = new object();

        /// <summary>
        /// Create the api client
        /// </summary>
        /// <param name="client">User managed either through httpclientfactory.create or by passing in new httpclient</param>
        /// <param name="key">Optional: Registered api key. See doc limitations when empty string is passed in</param>
        /// <returns>Api client</returns>
        public PokemonApiClient(HttpClient client, string key = "")
        {
            // We want the end user to pass in their httpclient to manage it
            // See https://github.com/dotnet/aspnetcore/issues/28385#issuecomment-480548175
            _client = GetClient(client, key);
        }

        private HttpClient GetClient(HttpClient client, string key = "")
        {
            lock (_clientLock)
            {
                client.BaseAddress = new Uri("https://api.pokemontcg.io/v2/");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("X-Api-Key", key);
                client.Timeout = TimeSpan.FromMinutes(10);
                return client;
            }
        }

        public async Task<Attempt<SetResponse>> GetSets()
        {
            var sets = await AttemptGet<SetResponse>($"sets/");
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

            var response = await _client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead);
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