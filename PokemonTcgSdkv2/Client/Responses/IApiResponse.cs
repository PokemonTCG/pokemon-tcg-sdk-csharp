namespace PokemonTcgSdkV2.Client.Responses
{
    /// <summary>
    ///     Simple interface for api responses.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IApiResponse<T>
    {
        /// <summary>
        ///     Data of the specific api response.
        /// </summary>
        T Data { get; set; }
    }
}