using System.Collections.Generic;

namespace PokemonTcgSdk
{
    public class SuperTypes
    {
        public static T Get<T>(string type, Dictionary<string, string> args = null)
        {
            return QueryBuilder.Get<T>(type, args);
        }

        public static T Find<T>(string type, string id)
        {
            return QueryBuilder.Find<T>(type, id);
        }
    }
}
