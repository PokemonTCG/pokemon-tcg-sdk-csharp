using System;

namespace PokemonTcgSdkV2.Utils.Exceptions
{
    /// <summary>
    ///     Exception which hints that an expected endpoint ist missing.
    /// </summary>
    public class MissingEndpointException : PokemonTcgException
    {
        /// <inheritdoc />
        public MissingEndpointException()
        {
        }

        /// <inheritdoc />
        public MissingEndpointException(string message) : base(message)
        {
        }

        /// <inheritdoc />
        public MissingEndpointException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}