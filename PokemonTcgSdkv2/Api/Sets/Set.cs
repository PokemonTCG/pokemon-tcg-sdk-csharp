using PokemonTcgSdkV2.Api.Cards;
using PokemonTcgSdkV2.Client.Endpoints;

namespace PokemonTcgSdkV2.Api.Sets
{
    /// <summary>
    ///     Represents a set of Pokémon <see cref="Card" />.
    /// </summary>
    public class Set : FetchableApiObject, IApiObjectWithId
    {
        static Set()
        {
            EndpointFactory.RegisterTypeEndpoint<Set>(new SetEndpoint());
        }

        /// <summary>
        ///     The name of the set.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     The series the set belongs to, like Sword and Shield or Base.
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        ///     The number printed on the card that represents the total.
        /// </summary>
        /// <remarks>
        ///     This total does not include secret rares.
        /// </remarks>
        public int PrintedTotal { get; set; }

        /// <summary>
        ///     The total number of cards in the set, including secret rares, alternate art, etc.
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        ///     The legalities for a given card.
        /// </summary>
        /// <remarks>
        ///     A legality will not be present in the <see cref="Legalities" /> if it is not legal. If it is legal or banned, it
        ///     will be present.
        /// </remarks>
        public Legalities Legalities { get; set; }

        /// <summary>
        ///     The code the Pokémon Trading Card Game Online uses to identify a set.
        /// </summary>
        public string PtcgoCode { get; set; }

        /// <summary>
        ///     The date the set was released (in the USA). Format is YYYY/MM/DD.
        /// </summary>
        public string ReleaseDate { get; set; }

        /// <summary>
        ///     The date and time the set was updated. Format is YYYY/MM/DD HH:MM:SS.
        /// </summary>
        public string UpdatedAt { get; set; }

        /// <summary>
        ///     Any images associated with the set, such as symbol and logo.
        /// </summary>
        public SetImages Images { get; set; }

        public string Id { get; set; }
    }
}