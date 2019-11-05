using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonTcgSdk
{
    public class Types
    {
        /// <summary>
        /// Get all of the Types.
        /// </summary>
        /// <returns></returns>
        public static async Task<List<string>> All()
        {
            return await QueryBuilder.GetTypes();
        }
    }
}