namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards.Models;

using System;

using Newtonsoft.Json;

public class CardImage
{
    [JsonProperty("small")]
    public Uri Small { get; set; }

    [JsonProperty("large")]
    public Uri Large { get; set; }

}