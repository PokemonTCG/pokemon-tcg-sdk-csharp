using PokemonTcgSdkV2.Api.Sets;

namespace PokemonTcgSdkV2.Client.Endpoints
{
    /// <summary>
    ///     Endpoint to fetch one or more <see cref="Set" />.
    /// </summary>
    public class SetEndpoint : IApiEndpoint
    {
        /// <inheritdoc />
        public string ApiUri()
        {
            return "sets";
        }
    }
}