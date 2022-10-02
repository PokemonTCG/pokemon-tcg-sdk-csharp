namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Types;

using System.Collections.Generic;

using Newtonsoft.Json;

public class ElementTypes : ResourceBase
{
    [JsonProperty("data")]
    public List<string> ElementType { get; set; }

    internal new static string ApiEndpoint { get; } = "types";

    public override string Id { get; set; }
}