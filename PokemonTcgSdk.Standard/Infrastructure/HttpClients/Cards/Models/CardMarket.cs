namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Cards.Models
{
    using System;

    using Newtonsoft.Json;

    public class CardMarket
    {
        [JsonProperty("url")] 
        public Uri Url { get; set; }

        [JsonProperty("updatedAt")] 
        public string UpdatedAt { get; set; }

        [JsonProperty("prices")] 
        public CardMarketPrices Prices { get; set; }
    }

    /// <summary>
    ///     Price information for a card.
    /// </summary>
    /// <remarks>All prices are in Euros.</remarks>
    public class CardMarketPrices
    {
        /// <summary>
        ///     The average sell price as shown in the chart at the website for non-foils.
        /// </summary>
        public decimal? AverageSellPrice { get; set; }

        /// <summary>
        ///     The lowest price at the market for non-foils.
        /// </summary>
        public decimal? LowPrice { get; set; }

        /// <summary>
        ///     The trend price as shown at the website (and in the chart) for non-foils.
        /// </summary>
        public decimal? TrendPrice { get; set; }

        /// <summary>
        ///     The average sell price as shown in the chart at the website for reverse holos.
        /// </summary>
        public decimal? ReverseHoloSell { get; set; }

        /// <summary>
        ///     The lowest price at the market as shown at the website (for condition EX+) for reverse holos.
        /// </summary>
        public decimal? ReverseHoloLow { get; set; }

        /// <summary>
        ///     The trend price as shown at the website (and in the chart) for reverse holos.
        /// </summary>
        public decimal? ReverseHoloTrend { get; set; }

        /// <summary>
        ///     The lowest price at the market for non-foils with condition EX or better.
        /// </summary>
        public decimal? LowPriceExPlus { get; set; }

        /// <summary>
        ///     The average sale price over the last day.
        /// </summary>
        [JsonProperty("avg1")]
        public decimal? AverageDay { get; set; }

        /// <summary>
        ///     The average sale price over the last 7 days.
        /// </summary>
        [JsonProperty("avg7")]
        public decimal? AverageWeek { get; set; }

        /// <summary>
        ///     The average sale price over the last 30 days.
        /// </summary>
        [JsonProperty("avg30")]
        public decimal? AverageMonth { get; set; }

        /// <summary>
        ///     The average sale price over the last day for reverse holos.
        /// </summary>
        [JsonProperty("reverseHoloAvg1")]
        public decimal? AverageDayReverseHolo { get; set; }

        /// <summary>
        ///     The average sale price over the last 7 days for reverse holos.
        /// </summary>
        [JsonProperty("reverseHoloAvg7")]
        public decimal? AverageWeekReverseHolo { get; set; }

        /// <summary>
        ///     The average sale price over the last 30 days for reverse holos.
        /// </summary>
        [JsonProperty("reverseHoloAvg30")]
        public decimal? AverageMonthReverseHolo { get; set; }
    }
}