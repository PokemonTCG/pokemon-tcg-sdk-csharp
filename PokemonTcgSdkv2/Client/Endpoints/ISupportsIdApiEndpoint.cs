namespace PokemonTcgSdkV2.Client.Endpoints
{
    public interface ISupportsIdApiEndpoint<in T> : IApiEndpoint
    {
        string IdPath();
    }
}