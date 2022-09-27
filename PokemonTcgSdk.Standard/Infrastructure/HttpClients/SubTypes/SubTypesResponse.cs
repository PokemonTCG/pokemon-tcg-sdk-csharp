namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.SubTypes;

using System.Collections.Generic;
using Newtonsoft.Json;

public class SubTypesResponse
{
    [JsonProperty("data")]
    public List<string> SubTypes { get; set; }
}