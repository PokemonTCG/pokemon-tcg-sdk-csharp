using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using PokemonTcgSdkV2.Api;

namespace PokemonTcgSdkV2.Client.Endpoints
{
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

        public static void RegisterTypeEndpoint<T>(IApiEndpoint endpoint) where T : FetchableApiObject
        {
            EndpointMapping.Add(typeof(T), endpoint);
        }

        public static IApiEndpoint GetApiEndpoint<T>() where T : FetchableApiObject
        {
            foreach (var endpointMappingKey in EndpointMapping.Keys.Where(endpointMappingKey =>
                typeof(T) == endpointMappingKey))
                return EndpointMapping[endpointMappingKey];

            throw new Exception("No endpoint registered.");
        }
    }
}