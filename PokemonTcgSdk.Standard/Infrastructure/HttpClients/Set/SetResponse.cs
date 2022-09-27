namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Set;

using System.Collections.Generic;
using Newtonsoft.Json;

public class SetResponse
{
    [JsonProperty("data")]
    public List<Set> Sets { get; set; }

    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("pageSize")]
    public int PageSize { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("totalCount")]
    public int TotalCount { get; set; }
}