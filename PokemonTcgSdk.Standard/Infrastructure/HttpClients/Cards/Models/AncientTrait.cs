namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards.Models;

using Newtonsoft.Json;

public class AncientTrait
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }
}