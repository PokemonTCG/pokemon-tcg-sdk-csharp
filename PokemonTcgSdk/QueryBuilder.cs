using PokemonTcgSdk.Helpers;
using PokemonTcgSdk.Models;
using System;
using System.Collections.Generic;

namespace PokemonTcgSdk
{
    public class QueryBuilder
    {
        public static T Get<T>(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                var type = QueryBuilderHelper.GetType<T>(ref query);

                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client, type);
                    return QueryBuilderHelper.CreateObject<T>(stringTask);
                }
            }
            catch (Exception ex)
            {
                return (T)Convert.ChangeType(ex.Message, typeof(T));
            }
        }

        public static Pokemon GetPokemonCards(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client);
                    return QueryBuilderHelper.CreateObject<Pokemon>(stringTask);
                }
            }
            catch (Exception ex)
            {
                var pokemon = new Pokemon { Errors = new List<string> { ex.Message } };
                return pokemon;
            }
        }

        public static SetData GetSets(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;

                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client);
                    return QueryBuilderHelper.CreateObject<SetData>(stringTask);
                }
            }
            catch (Exception ex)
            {
                var set = new SetData { Errors = new List<string> { ex.Message } };
                return set;
            }
        }

        public static List<string> GetSuperTypes(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                var superTypes = new List<string>();
                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask =
                        QueryBuilderHelper.BuildTaskString(null, ref queryString, client, ResourceTypes.SuperTypes);
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

        public static List<string> GetTypes(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                var superTypes = new List<string>();
                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask =
                        QueryBuilderHelper.BuildTaskString(null, ref queryString, client, ResourceTypes.Types);
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

        public static List<string> GetSubTypes(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                var superTypes = new List<string>();
                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask =
                        QueryBuilderHelper.BuildTaskString(null, ref queryString, client, ResourceTypes.SubTypes);
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