namespace PokemonTcgSdkV2.Client.Endpoints
{
    public interface IQueryableApiEndpoint : IApiEndpoint
    {
        string BuildQueryString(string query);
    }
}