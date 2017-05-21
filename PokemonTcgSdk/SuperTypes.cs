using PokemonTcgSdk.Helpers;
using PokemonTcgSdk.Models;
using System.Collections.Generic;
using System.Net.Http;

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
    }
}
