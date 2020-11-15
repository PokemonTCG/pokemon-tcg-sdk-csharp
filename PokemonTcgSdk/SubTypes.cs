using System.Collections.Generic;
using System.Threading.Tasks;

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

        /// <summary>
        /// Async: Get all of the SubTypes.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<string>> AllAsync()
        {
            return await QueryBuilder.GetSubTypesAsync();
        }
    }
}