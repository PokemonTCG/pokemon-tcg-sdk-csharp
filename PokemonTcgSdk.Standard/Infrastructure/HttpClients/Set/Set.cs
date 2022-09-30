namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients.Set
{
    using CommonModels;
    using Newtonsoft.Json;

    public class Set : ApiResource
    {
        public override string Id { get; set; }

        internal new static string ApiEndpoint { get; } = "sets";

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