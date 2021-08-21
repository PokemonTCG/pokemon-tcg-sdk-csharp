using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using PokemonTcgSdkV2.Api;

namespace PokemonTcgSdkV2.Client.Responses
{
    public static class ResponseFactory
    {
        static ResponseFactory()
        {
            var knownTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t =>
                typeof(FetchableApiObject).IsAssignableFrom(t) &&
                t != typeof(FetchableApiObject));

            foreach (var knownType in knownTypes) RuntimeHelpers.RunClassConstructor(knownType.TypeHandle);
        }

        private static Dictionary<Type, Type> ResponseMapping { get; } =
            new Dictionary<Type, Type>();

        public static void RegisterTypeResponse<T1, T2>()
            where T1 : FetchableApiObject where T2 : IApiResponse<T1>
        {
            ResponseMapping.Add(typeof(T1), typeof(T2));
        }

        public static Type GetApiResponse<T>() where T : FetchableApiObject
        {
            foreach (var responseMappingKey in ResponseMapping.Keys.Where(responseMappingKey =>
                typeof(T) == responseMappingKey))
                return ResponseMapping[responseMappingKey];
            //return Activator.CreateInstance(ResponseMapping[responseMappingKey]) as IApiResponse<T>;

            throw new Exception("No response registered.");
        }
    }
}