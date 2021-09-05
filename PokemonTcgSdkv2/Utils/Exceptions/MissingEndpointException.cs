using System;

namespace PokemonTcgSdkV2.Utils.Exceptions
{
    public class MissingEndpointException : PokemonTcgException
    {
        public MissingEndpointException()
        {
        }

        public MissingEndpointException(string message) : base(message)
        {
        }

        public MissingEndpointException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}