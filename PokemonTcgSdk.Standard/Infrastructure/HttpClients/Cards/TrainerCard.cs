namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;

using System.Collections.Generic;

using CommonModels;
using Models;
using Newtonsoft.Json;
using Set;

public class TrainerCard : ApiResource
{
    internal new static string ApiEndpoint { get; } = "cards?q=supertype:trainer";

    public override string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("supertype")]
    public string Supertype { get; set; }

    [JsonProperty("rules")]
    public List<string> Rules { get; set; }

    [JsonProperty("set")]
    public Set Set { get; set; }

    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("artist", NullValueHandling = NullValueHandling.Ignore)]
    public string Artist { get; set; }

    [JsonProperty("rarity", NullValueHandling = NullValueHandling.Ignore)]
    public string Rarity { get; set; }

    [JsonProperty("legalities")]
    public Legalities Legalities { get; set; }

    [JsonProperty("images")]
    public CardImage Images { get; set; }

    [JsonProperty("tcgplayer", NullValueHandling = NullValueHandling.Ignore)]
    public TcgPlayer Tcgplayer { get; set; }

    [JsonProperty("cardmarket", NullValueHandling = NullValueHandling.Ignore)]
    public CardMarket Cardmarket { get; set; }

    [JsonProperty("subtypes", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Subtypes { get; set; }

    [JsonProperty("attacks", NullValueHandling = NullValueHandling.Ignore)]
    public List<Attack> Attacks { get; set; }

    [JsonProperty("regulationMark", NullValueHandling = NullValueHandling.Ignore)]
    public string RegulationMark { get; set; }

    [JsonProperty("hp", NullValueHandling = NullValueHandling.Ignore)]
    public int Hp { get; set; }

    [JsonProperty("abilities", NullValueHandling = NullValueHandling.Ignore)]
    public List<Ability> Abilities { get; set; }
}