using System;

namespace PokemonTcgSdkV2.Utils.Exceptions
{
    /// <summary>
    ///     Exception classed used for exceptions caused in the Pokémon TCG api.
    /// </summary>
    public class PokemonTcgException : Exception
    {
        /// <summary>
        ///     Creates a new Exception instance.
        /// </summary>
        public PokemonTcgException() : base("An unknown error in the Pokémon TCG api has been raised.")
        {
        }

        /// <summary>
        ///     Creates a new Exception instance with a message.
        /// </summary>
        /// <param name="message">Message of the exception.</param>
        public PokemonTcgException(string message) : base(message)
        {
        }

        /// <summary>
        ///     Creates a new Exception instance with a message and a contained inner exception.
        /// </summary>
        /// <param name="message">Message of the exception.</param>
        /// <param name="innerException">Contained inner exception.</param>
        public PokemonTcgException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}