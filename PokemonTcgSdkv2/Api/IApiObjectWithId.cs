namespace PokemonTcgSdkV2.Api
{
    /// <summary>
    ///     Represents an object from the API which supports an id.
    /// </summary>
    public interface IApiObjectWithId
    {
        /// <summary>
        ///     String representation of the objects id.
        /// </summary>
        string Id { get; set; }
    }
}