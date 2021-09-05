using System;

namespace PokemonTcgSdkV2.Utils.Exceptions
{
    public class PokemonTcgException : Exception
    {
        public PokemonTcgException() : base("An unknown error in the Pokémon TCG api has been raised.")
        {
        }

        public PokemonTcgException(string message) : base(message)
        {
        }

        public PokemonTcgException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}