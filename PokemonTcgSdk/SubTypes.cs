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
        public static async Task<List<string>> All()
        {
            return await QueryBuilder.GetSubTypes();
        }
    }
}