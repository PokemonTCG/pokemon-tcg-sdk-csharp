namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;

using System.Collections.Generic;

using CommonModels;
using Models;
using Newtonsoft.Json;
using Set;

public class PokemonCard : ApiResource
{
    internal new static string ApiEndpoint { get; } = "cards?q=supertype:pokemon";
    public override string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("supertype")]
    public string Supertype { get; set; }

    [JsonProperty("subtypes")]
    public List<string> Subtypes { get; set; }

    [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
    public string Level { get; set; }

    [JsonProperty("hp")]
    public int Hp { get; set; }

    [JsonProperty("types")]
    public List<string> Types { get; set; }

    [JsonProperty("evolvesFrom")]
    public string EvolvesFrom { get; set; }

    [JsonProperty("ancientTrait")]
    public AncientTrait AncientTrait { get; set; }

    [JsonProperty("abilities")]
    public List<Ability> Abilities { get; set; }

    [JsonProperty("attacks")]
    public List<Attack> Attacks { get; set; }

    [JsonProperty("weaknesses")]
    public List<Resistance> Weaknesses { get; set; }

    [JsonProperty("resistances")]
    public List<Resistance> Resistances { get; set; }

    [JsonProperty("retreatCost")]
    public List<string> RetreatCost { get; set; }

    [JsonProperty("convertedRetreatCost")]
    public int ConvertedRetreatCost { get; set; }

    [JsonProperty("set")]
    public Set Set { get; set; }

    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("artist")]
    public string Artist { get; set; }

    [JsonProperty("rarity")]
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

    [JsonProperty("evolvesTo")]
    public List<string> EvolvesTo { get; set; }

    [JsonProperty("flavorText")]
    public string FlavorText { get; set; }

    [JsonProperty("rules")]
    public List<string> Rules { get; set; }

    [JsonProperty("regulationMark")]
    public string RegulationMark { get; set; }
}