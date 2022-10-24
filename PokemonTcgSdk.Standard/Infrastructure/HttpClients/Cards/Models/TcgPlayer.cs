﻿namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards.Models
{
    using System;

    using Newtonsoft.Json;

    public class TcgPlayer
    {
        [JsonProperty("url")] 
        public Uri Url { get; set; }

        [JsonProperty("updatedAt")] 
        public string UpdatedAt { get; set; }

        [JsonProperty("prices")] 
        public TcgPlayerPrices Prices { get; set; }
    }

    /// <summary>
    ///     Price information for a card.
    /// </summary>
    /// <remarks>All prices are in US Dollars.</remarks>
    public class TcgPlayerPrices
    {
        [JsonProperty("holofoil", NullValueHandling = NullValueHandling.Ignore)]
        public Prices Holofoil { get; set; }

        [JsonProperty("reverseHolofoil", NullValueHandling = NullValueHandling.Ignore)]
        public Prices ReverseHolofoil { get; set; }

        [JsonProperty("normal", NullValueHandling = NullValueHandling.Ignore)]
        public Prices Normal { get; set; }

        [JsonProperty("1stEditionHolofoil", NullValueHandling = NullValueHandling.Ignore)]
        public Prices The1StEditionHolofoil { get; set; }

        [JsonProperty("unlimitedHolofoil", NullValueHandling = NullValueHandling.Ignore)]
        public Prices UnlimitedHolofoil { get; set; }
    }

    public class Prices
    {
        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("mid")]
        public double Mid { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("market")]
        public double Market { get; set; }

        [JsonProperty("directLow", NullValueHandling = NullValueHandling.Ignore)]
        public double? DirectLow { get; set; }
    }
}
