namespace PokemonTcgSdkV2.Client.Responses
{
    public interface IApiResponse<T>
    {
        T Data { get; set; }
    }
}