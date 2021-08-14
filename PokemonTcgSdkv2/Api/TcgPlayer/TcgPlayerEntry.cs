namespace PokemonTcgSdkV2.Api.TcgPlayer
{
    public class TcgPlayerEntry
    {
        public string Url { get; set; }

        public string UpdatedAt { get; set; }

        public TcgPlayerPriceSet Prices { get; set; }
    }
}