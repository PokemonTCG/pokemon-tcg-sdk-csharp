﻿namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards;

using Newtonsoft.Json;

public class Resistance
{
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }
}