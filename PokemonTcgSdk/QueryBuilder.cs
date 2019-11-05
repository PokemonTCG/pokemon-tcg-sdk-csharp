using PokemonTcgSdk.Helpers;
using PokemonTcgSdk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonTcgSdk
{
    public class QueryBuilder
    {
        public static async Task<T> Get<T>(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                var type = QueryBuilderHelper.GetType<T>(ref query);

                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = await QueryBuilderHelper.BuildTaskString(query, queryString, client, type);
                    return QueryBuilderHelper.CreateObject<T>(stringTask);
                }
            }
            catch (Exception ex)
            {
                return (T)Convert.ChangeType(ex.Message, typeof(T));
            }
        }

        public static async Task<Pokemon> GetPokemonCards(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = await QueryBuilderHelper.BuildTaskString(query, queryString, client);
                    return QueryBuilderHelper.CreateObject<Pokemon>(stringTask);
                }
            }
            catch (Exception ex)
            {
                return new Pokemon { Errors = new List<string> { ex.Message } };
            }
        }

        public static async Task<SetData> GetSets(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;

                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = await QueryBuilderHelper.BuildTaskString(query, queryString, client);
                    return QueryBuilderHelper.CreateObject<SetData>(stringTask);
                }
            }
            catch (Exception ex)
            {
                return new SetData { Errors = new List<string> { ex.Message } };
            }
        }

        public static async Task<List<string>> GetSuperTypes(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                var superTypes = new List<string>();
                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask =
                        await QueryBuilderHelper.BuildTaskString(null, queryString, client, ResourceTypes.SuperTypes);
                    var type = QueryBuilderHelper.CreateObject<SuperType>(stringTask);
                    superTypes.AddRange(type.Types);
                    return superTypes;
                }
            }
            catch (Exception ex)
            {
                return new List<string> { ex.Message };
            }
        }

        public static async Task<List<string>> GetTypes(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                var superTypes = new List<string>();
                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask =
                        await QueryBuilderHelper.BuildTaskString(null, queryString, client, ResourceTypes.Types);
                    var type = QueryBuilderHelper.CreateObject<TypeData>(stringTask);
                    superTypes.AddRange(type.Types);
                    return superTypes;
                }
            }
            catch (Exception ex)
            {
                return new List<string> { ex.Message };
            }
        }

        public static async Task<List<string>> GetSubTypes(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                var superTypes = new List<string>();
                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask =
                        await QueryBuilderHelper.BuildTaskString(null, queryString, client, ResourceTypes.SubTypes);
                    var type = QueryBuilderHelper.CreateObject<SubType>(stringTask);
                    superTypes.AddRange(type.Types);
                    return superTypes;
                }
            }
            catch (Exception ex)
            {
                return new List<string> { ex.Message };
            }
        }

        public static T Find<T>(string id)
        {
            try
            {
                var type = QueryBuilderHelper.GetType<T>();

                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = client.GetAsync($"{type}/{id}").Result;
                    return QueryBuilderHelper.CreateObject<T>(stringTask);
                }
            }
            catch (Exception ex)
            {
                return (T)Convert.ChangeType(ex.Message, typeof(T));
            }
        }
    }
}