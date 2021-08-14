using System.Text.Json.Serialization;

namespace PokemonTcgSdk.Api.Cardmarket
{
    public class CardmarketPrice
    {
        public decimal AverageSellPrice { get; set; }

        public decimal LowPrice { get; set; }

        public decimal TrendPrice { get; set; }

        public decimal GermanProLow { get; set; }

        public decimal SuggestedPrice { get; set; }

        public decimal ReverseHoloSell { get; set; }

        public decimal reverseHoloLow { get; set; }

        public decimal LowPriceExPlus { get; set; }

        [JsonPropertyName("avg1")] public decimal AverageDay { get; set; }

        [JsonPropertyName("avg7")] public decimal AverageWeek { get; set; }

        [JsonPropertyName("avg30")] public decimal AverageMonth { get; set; }

        [JsonPropertyName("reverseHoloAvg1")] public decimal AverageDayReverseHolo { get; set; }

        [JsonPropertyName("reverseHoloAvg7")] public decimal AverageWeekReverseHolo { get; set; }

        [JsonPropertyName("reverseHoloAvg30")] public decimal AverageMonthReverseHolo { get; set; }
    }
}