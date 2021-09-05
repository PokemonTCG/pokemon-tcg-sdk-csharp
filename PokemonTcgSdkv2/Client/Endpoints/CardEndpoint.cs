namespace PokemonTcgSdkV2.Client.Endpoints
{
    public class CardEndpoint : ISupportsIdApiEndpoint
    {
        public string ApiUri()
        {
            return "cards";
        }

        public string IdPath()
        {
            return "id";
        }
    }
}