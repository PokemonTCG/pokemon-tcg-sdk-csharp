using PokemonTcgSdkV2.Api;

namespace PokemonTcgSdkV2.Client.Responses
{
    /// <summary>
    ///     Single response object of an api request.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleApiResponse<T> : IApiResponse<T> where T : FetchableApiObject
    {
        /// <summary>
        ///     Data object of the api request.
        /// </summary>
        public T Data { get; set; }
    }
}