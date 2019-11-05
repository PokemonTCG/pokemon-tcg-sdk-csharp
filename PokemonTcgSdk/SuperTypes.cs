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
        public static async Task<List<string>> All()
        {
            return await QueryBuilder.GetSuperTypes();
        }
    }
}