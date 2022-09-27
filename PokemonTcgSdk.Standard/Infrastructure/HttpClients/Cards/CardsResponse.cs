namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;

using System.Collections.Generic;
using Newtonsoft.Json;

public class CardsResponse
{
    [JsonProperty("data")]
    public List<Card> Cards { get; set; }

    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("pageSize")]
    public int PageSize { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("totalCount")]
    public int TotalCount { get; set; }
}