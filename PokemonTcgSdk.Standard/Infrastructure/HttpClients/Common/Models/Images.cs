﻿namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Common.Models;

using System;
using Newtonsoft.Json;

public class Images
{
    [JsonProperty("symbol")]
    public Uri Symbol { get; set; }

    [JsonProperty("logo")]
    public Uri Logo { get; set; }
}