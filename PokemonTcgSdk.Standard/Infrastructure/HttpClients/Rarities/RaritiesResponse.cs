namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Rarities;

using System.Collections.Generic;
using Newtonsoft.Json;

public class RaritiesResponse
{
    [JsonProperty("data")]
    public List<string> Rarities { get; set; }
}