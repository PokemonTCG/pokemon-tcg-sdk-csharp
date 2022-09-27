﻿namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Common.Models;

using Newtonsoft.Json;

public class Legalities
{
    [JsonProperty("unlimited")]
    public string Unlimited { get; set; }

    [JsonProperty("standard")]
    public string Standard { get; set; }

    [JsonProperty("expanded")]
    public string Expanded { get; set; }
}