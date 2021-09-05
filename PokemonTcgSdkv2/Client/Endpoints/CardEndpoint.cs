namespace PokemonTcgSdkV2.Client.Endpoints
{
    public class CardEndpoint : ISupportsIdApiEndpoint<string>
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