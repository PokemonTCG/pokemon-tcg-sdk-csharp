﻿using System.Text.Json.Serialization;

namespace PokemonTcgSdk.Api.Sets
{
    public class SetImages
    {
        [JsonPropertyName("symbol")] public string SymbolImageUrl { get; set; }

        [JsonPropertyName("logo")] public string LogoImageUrl { get; set; }
    }
}