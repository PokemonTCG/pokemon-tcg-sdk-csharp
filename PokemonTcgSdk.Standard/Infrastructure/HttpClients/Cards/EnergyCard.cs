namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;

using System.Collections.Generic;

using Models;
using Newtonsoft.Json;
using CommonModels;
using Set;

public class EnergyCard : ApiResource
{
    internal new static string ApiEndpoint { get; } = "cards?q=supertype:energy";

    public override string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("supertype")]
    public string Supertype { get; set; }

    [JsonProperty("subtypes")]
    public List<string> Subtypes { get; set; }

    [JsonProperty("rules", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Rules { get; set; }

    [JsonProperty("set")]
    public Set Set { get; set; }

    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("artist", NullValueHandling = NullValueHandling.Ignore)]
    public string Artist { get; set; }

    [JsonProperty("rarity")]
    public string Rarity { get; set; }

    [JsonProperty("legalities")]
    public Legalities Legalities { get; set; }

    [JsonProperty("images")]
    public CardImage Images { get; set; }

    [JsonProperty("tcgplayer", NullValueHandling = NullValueHandling.Ignore)]
    public TcgPlayer Tcgplayer { get; set; }

    [JsonProperty("cardmarket", NullValueHandling = NullValueHandling.Ignore)]
    public CardMarket Cardmarket { get; set; }
}