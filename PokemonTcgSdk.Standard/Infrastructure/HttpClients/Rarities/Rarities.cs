namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Rarities;

using System.Collections.Generic;

using Newtonsoft.Json;

public class Rarities : ResourceBase
{
    [JsonProperty("data")]
    public List<string> Rarity { get; set; }

    internal new static string ApiEndpoint { get; } = "rarities";

    public override string Id { get; set; }
}