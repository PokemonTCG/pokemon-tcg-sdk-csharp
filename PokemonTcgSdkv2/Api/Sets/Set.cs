using PokemonTcgSdkV2.Api.Cards;
using PokemonTcgSdkV2.Client.Endpoints;

namespace PokemonTcgSdkV2.Api.Sets
{
    public class Set : FetchableApiObject, IApiObjectWithId
    {
        static Set()
        {
            EndpointFactory.RegisterTypeEndpoint<Set>(new SetEndpoint());
        }

        public string Name { get; set; }

        public string Series { get; set; }

        public int PrintedTotal { get; set; }

        public int Total { get; set; }

        public Legalities Legalities { get; set; }

        public string PtcgoCode { get; set; }

        public string ReleaseDate { get; set; }

        public string UpdatedAt { get; set; }

        public SetImages Images { get; set; }

        public string Id { get; set; }
    }
}