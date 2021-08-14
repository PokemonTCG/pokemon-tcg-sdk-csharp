namespace PokemonTcgSdkV2.Api.Cardmarket
{
    public class CardmarketEntry
    {
        public string Url { get; set; }

        public string UpdatedAt { get; set; }

        public CardmarketPrice Prices { get; set; }
    }
}