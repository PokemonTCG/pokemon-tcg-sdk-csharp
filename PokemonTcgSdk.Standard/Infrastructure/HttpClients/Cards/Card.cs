namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;

using System.Collections.Generic;

using CommonModels;
using Models;
using Newtonsoft.Json;
using Set;

public class Card : ApiResource
{
    public override string Id { get; set; }

    internal new static string ApiEndpoint { get; } = "cards";

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("supertype")]
    public string Supertype { get; set; }

    [JsonProperty("subtypes")]
    public List<string> Subtypes { get; set; }

    [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
    public string Level { get; set; }

    [JsonProperty("hp", NullValueHandling = NullValueHandling.Ignore)]
    public int Hp { get; set; }

    [JsonProperty("types")]
    public List<string> Types { get; set; }

    [JsonProperty("evolvesFrom", NullValueHandling = NullValueHandling.Ignore)]
    public string EvolvesFrom { get; set; }

    [JsonProperty("ancientTrait", NullValueHandling = NullValueHandling.Ignore)]
    public AncientTrait AncientTrait { get; set; }

    [JsonProperty("abilities", NullValueHandling = NullValueHandling.Ignore)]
    public List<Ability> Abilities { get; set; }

    [JsonProperty("attacks", NullValueHandling = NullValueHandling.Ignore)]
    public List<Attack> Attacks { get; set; }

    [JsonProperty("weaknesses", NullValueHandling = NullValueHandling.Ignore)]
    public List<Resistance> Weaknesses { get; set; }

    [JsonProperty("resistances", NullValueHandling = NullValueHandling.Ignore)]
    public List<Resistance> Resistances { get; set; }

    [JsonProperty("retreatCost", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> RetreatCost { get; set; }

    [JsonProperty("convertedRetreatCost", NullValueHandling = NullValueHandling.Ignore)]
    public int ConvertedRetreatCost { get; set; }

    [JsonProperty("set")]
    public Set Set { get; set; }

    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("artist")]
    public string Artist { get; set; }

    [JsonProperty("rarity", NullValueHandling = NullValueHandling.Ignore)]
    public string Rarity { get; set; }

    [JsonProperty("nationalPokedexNumbers")]
    public List<int> NationalPokedexNumbers { get; set; }

    [JsonProperty("legalities")]
    public Legalities Legalities { get; set; }

    [JsonProperty("images")]
    public CardImage Images { get; set; }

    [JsonProperty("tcgplayer")]
    public TcgPlayer Tcgplayer { get; set; }

    [JsonProperty("cardmarket")]
    public CardMarket Cardmarket { get; set; }

    [JsonProperty("evolvesTo", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> EvolvesTo { get; set; }

    [JsonProperty("flavorText", NullValueHandling = NullValueHandling.Ignore)]
    public string FlavorText { get; set; }

    [JsonProperty("rules", NullValueHandling = NullValueHandling.Ignore)]
    public List<string> Rules { get; set; }

    [JsonProperty("regulationMark", NullValueHandling = NullValueHandling.Ignore)]
    public string RegulationMark { get; set; }
}