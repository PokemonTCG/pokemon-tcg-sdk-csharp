using PokemonTcgSdkV2.Api.Cards;

namespace PokemonTcgSdkV2.Client.Endpoints
{
    /// <summary>
    ///     Endpoint to fetch one or more <see cref="Card" />.
    /// </summary>
    public class CardEndpoint : IApiEndpoint
    {
        /// <inheritdoc />
        public string ApiUri()
        {
            return "cards";
        }
    }
}