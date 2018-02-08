using System;

namespace PokemonTcgSdk.Annotations
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class EntityHeadersAttribute : Attribute
    {
        public EntityHeadersAttribute()
        {
        }

        public EntityHeadersAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}