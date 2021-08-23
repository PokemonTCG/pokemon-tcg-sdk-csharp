using PokemonTcgSdkV2.Api;

namespace PokemonTcgSdkV2.Client.Responses
{
    public class SingleApiResponse<T> : IApiResponse<T> where T : FetchableApiObject
    {
        public T Data { get; set; }
    }
}