namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Set
{
    using Common.Models;
    using Newtonsoft.Json;

    public class Set
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("series")]
        public string Series { get; set; }

        [JsonProperty("printedTotal")]
        public long PrintedTotal { get; set; }

        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("legalities")]
        public Legalities Legalities { get; set; }

        [JsonProperty("ptcgoCode")]
        public string PtcgoCode { get; set; }

        [JsonProperty("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }
    }
}