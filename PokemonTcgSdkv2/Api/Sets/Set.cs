using PokemonTcgSdk.Api.Cards;

namespace PokemonTcgSdk.Api.Sets
{
    public class Set
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Series { get; set; }

        public int PrintedTotal { get; set; }

        public int Total { get; set; }

        public Legalities Legalities { get; set; }

        public string PtcgoCode { get; set; }

        public string ReleaseDate { get; set; }

        public string UpdatedAt { get; set; }

        public SetImages Images { get; set; }
    }
}