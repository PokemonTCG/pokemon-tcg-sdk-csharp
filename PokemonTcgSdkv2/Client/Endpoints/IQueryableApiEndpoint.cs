namespace PokemonTcgSdkV2.Client.Endpoints
{
    /// <summary>
    ///     Interface for special endpoints, which support queries.
    /// </summary>
    public interface IQueryableApiEndpoint : IApiEndpoint
    {
        /// <summary>
        ///     Builds the query string for the uri.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>
        ///     Query string of the uri.
        /// </returns>
        string BuildQueryString(string query);
    }
}