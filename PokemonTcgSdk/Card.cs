using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System;

namespace PokemonTcgSdk
{
    public static class Card
    {
        public static T Get<T>(string type, Dictionary<string, string> args = null)
        {
            return QueryBuilder.Get<T>(type, args);
        }

        public static T Find<T>(string id)
        {
            return QueryBuilder.Find<T>(id);
        }
    }
}