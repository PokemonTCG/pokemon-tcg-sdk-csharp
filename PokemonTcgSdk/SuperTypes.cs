using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonTcgSdk
{
    public class SuperTypes
    {
        /// <summary>
        /// Get all of the SuperTypes.
        /// </summary>
        /// <returns></returns>
        public static List<string> All()
        {
            return QueryBuilder.GetSuperTypes();
        }

        /// <summary>
        /// Async: Get all of the SuperTypes.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<string>> AllAsync()
        {
            return await QueryBuilder.GetSuperTypesAsync();
        }
    }
}