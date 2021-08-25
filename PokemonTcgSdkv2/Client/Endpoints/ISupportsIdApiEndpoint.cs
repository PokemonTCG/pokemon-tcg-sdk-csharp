namespace PokemonTcgSdkV2.Client.Endpoints
{
    /// <summary>
    ///     Interface for special endpoints, which support fetch by id.
    /// </summary>
    public interface ISupportsIdApiEndpoint : IApiEndpoint
    {
        /// <summary>
        ///     <see cref="string" /> representation of the id in the uri.
        /// </summary>
        /// <returns>
        ///     Returns the uri of the id.
        /// </returns>
        string IdPath();
    }
}