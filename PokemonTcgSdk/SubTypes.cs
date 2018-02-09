using System.Collections.Generic;

namespace PokemonTcgSdk
{
    public class SubTypes
    {
        /// <summary>
        /// Get all of the SubTypes.
        /// </summary>
        /// <returns></returns>
        public static List<string> All()
        {
            return QueryBuilder.GetSubTypes();
        }
    }
}