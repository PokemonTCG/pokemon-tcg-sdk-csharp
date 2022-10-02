namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.SubTypes;

using System.Collections.Generic;

using Newtonsoft.Json;

public class SubTypes : ResourceBase
{
    public override string Id { get; set; }

    internal new static string ApiEndpoint { get; } = "subtypes";

    [JsonProperty("data")]
    public List<string> SubType { get; set; }

}