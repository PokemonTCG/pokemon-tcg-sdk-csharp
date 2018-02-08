using PokemonTcgSdk.Annotations;

namespace PokemonTcgSdk.Models
{
    public class PagingInfo
    {
        public string Link { get; set; }

        [EntityHeaders("Page-Size")]
        public int PageSize { get; set; }

        public int Count { get; set; }

        [EntityHeaders("Total-Count")]
        public int TotalCount { get; set; }

        [EntityHeaders("Ratelimit-Limit")]
        public int RatelimitLimit { get; set; }

        [EntityHeaders("Ratelimit-Remaining")]
        public int RatelimitRemaining { get; set; }
    }
}