using PokemonTcgSdk.Helpers;
using PokemonTcgSdk.Models;
using System.Collections.Generic;
using System.Net.Http;

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
