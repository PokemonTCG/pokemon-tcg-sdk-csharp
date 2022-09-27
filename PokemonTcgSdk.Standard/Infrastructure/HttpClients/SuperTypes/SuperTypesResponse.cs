namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.SuperTypes;

using System.Collections.Generic;
using Newtonsoft.Json;

public class SuperTypesResponse
{
    [JsonProperty("data")]
    public List<string> SuperTypes { get; set; }
}