namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.SuperTypes;

using System.Collections.Generic;

using Newtonsoft.Json;

public class SuperTypes : ResourceBase
{
    [JsonProperty("data")]
    public List<string> SuperType { get; set; }

    internal new static string ApiEndpoint { get; } = "supertypes";

    public override string Id { get; set; }
}