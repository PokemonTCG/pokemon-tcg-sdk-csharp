using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using PokemonTcgSdkV2.Api;

namespace PokemonTcgSdkV2.Client.Endpoints
{
    /// <summary>
    ///     Factory, to match an API endpoint with the class of a <see cref="FetchableApiObject" />.
    /// </summary>
    /// <remarks>
    ///     Add a class constructor to your own implementations of <see cref="FetchableApiObject" /> and call
    ///     <see cref="RegisterTypeEndpoint{T}" /> with its endpoint instance to publish it to the factory.
    /// </remarks>
    public static class EndpointFactory
    {
        static EndpointFactory()
        {
            var knownTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t =>
                typeof(FetchableApiObject).IsAssignableFrom(t) &&
                t != typeof(FetchableApiObject));

            foreach (var knownType in knownTypes) RuntimeHelpers.RunClassConstructor(knownType.TypeHandle);
        }

        private static Dictionary<Type, IApiEndpoint> EndpointMapping { get; } = new Dictionary<Type, IApiEndpoint>();

        /// <summary>
        ///     Register an endpoint for a type of object.
        /// </summary>
        /// <typeparam name="T">
        ///     Type of object the API endpoint will be used for. Must inherit from
        ///     <see cref="FetchableApiObject" />.
        /// </typeparam>
        /// <param name="endpoint">Endpoint instance to register.</param>
        public static void RegisterTypeEndpoint<T>(IApiEndpoint endpoint) where T : FetchableApiObject
        {
            EndpointMapping.Add(typeof(T), endpoint);
        }

        /// <summary>
        ///     Gets an endpoint for an object type.
        /// </summary>
        /// <typeparam name="T">Type of object you want the API endpoint for. Must inherit from <see cref="FetchableApiObject" />.</typeparam>
        /// <returns>
        ///     Instance of the API endpoint.
        /// </returns>
        public static IApiEndpoint GetApiEndpoint<T>() where T : FetchableApiObject
        {
            foreach (var endpointMappingKey in EndpointMapping.Keys.Where(endpointMappingKey =>
                typeof(T) == endpointMappingKey))
                return EndpointMapping[endpointMappingKey];

            throw new Exception("No endpoint registered.");
        }
    }
}