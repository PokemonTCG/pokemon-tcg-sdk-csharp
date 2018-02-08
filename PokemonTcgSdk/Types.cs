using System.Collections.Generic;

namespace PokemonTcgSdk
{
    public class Types
    {
        /// <summary>
        /// Get all of the Types.
        /// </summary>
        /// <returns></returns>
        public static List<string> All()
        {
            return QueryBuilder.GetTypes();
        }
    }
}