using PokemonTcgSdk.Annotations;
using PokemonTcgSdk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;

namespace PokemonTcgSdk.Mappers
{
    public class HttpResponseToPagingInfo
    {
        public static PagingInfo MapFrom(HttpResponseHeaders input)
        {
            var type = typeof(PagingInfo);
            var instance = Activator.CreateInstance(type);
            var properties = type.GetProperties().ToDictionary(p => p.Name, p => p);
            foreach (var property in properties)
            {
                var name = GetNameEntity(property);
                var value = GetValueEntity(name, input);
                if (value != null)
                {
                    property.Value.SetValue(instance, Convert.ChangeType(value, property.Value.PropertyType), null);
                }
            }
            return (PagingInfo)instance;
        }

        private static object GetValueEntity(string name, HttpResponseHeaders input)
        {
            IEnumerable<string> values = new List<string>();
            if (input.TryGetValues(name, out values))
            {
                return values.FirstOrDefault();
            }
            return null;
        }

        private static string GetNameEntity(KeyValuePair<string, PropertyInfo> property)
        {
            var attribute = property.Value.GetCustomAttribute<EntityHeadersAttribute>();
            if (attribute != null)
            {
                return attribute.Name;
            }
            return property.Key;
        }

    }
}
