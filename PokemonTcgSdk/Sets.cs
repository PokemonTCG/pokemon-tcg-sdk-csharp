using PokemonTcgSdk.Models;

namespace PokemonTcgSdk
{
    public class Sets
    {
        public static SetData Get()
        {
            return QueryBuilder.GetSets();
        }
    }
}
