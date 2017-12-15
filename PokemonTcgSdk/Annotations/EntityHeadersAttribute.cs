using System;

namespace PokemonTcgSdk.Annotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class EntityHeadersAttribute : Attribute
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public EntityHeadersAttribute()
        {
            
        }

        public EntityHeadersAttribute(string name)
        {
            this.name = name;
        }
        
    }
}