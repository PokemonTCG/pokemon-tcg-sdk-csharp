namespace PokemonTcgSdkV2.Client.Endpoints
{
    public class SetEndpoint : ISupportsIdApiEndpoint<string>
    {
        public string ApiUri()
        {
            return "sets";
        }

        public string IdPath()
        {
            return "id";
        }
    }
}