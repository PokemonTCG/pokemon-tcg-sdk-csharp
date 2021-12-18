namespace PokemonTcgSdkV2.Client.Endpoints
{
    /// <summary>
    ///     Interface for API endpoints.
    /// </summary>
    public interface IApiEndpoint
    {
        /// <summary>
        ///     The uri of the specific endpoint.
        /// </summary>
        /// <returns>
        ///     API uri as string.
        /// </returns>
        string ApiUri();
    }
}