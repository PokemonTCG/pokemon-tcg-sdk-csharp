namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Types;

using System.Collections.Generic;
using Newtonsoft.Json;

public class TypesResponse
{
    [JsonProperty("data")]
    public List<string> Types { get; set; }
}