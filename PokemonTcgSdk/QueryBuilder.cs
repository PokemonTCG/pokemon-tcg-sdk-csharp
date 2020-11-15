﻿using PokemonTcgSdk.Helpers;
using PokemonTcgSdk.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public static async Task<T> GetAsync<T>(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                var type = QueryBuilderHelper.GetType<T>(ref query);

                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = await QueryBuilderHelper.BuildTaskStringAsync(query, queryString, client, type);
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
                return new Pokemon { Errors = new List<string> { ex.Message } };
            }
        }

        public static async Task<Pokemon> GetPokemonCardsAsync(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = await QueryBuilderHelper.BuildTaskStringAsync(query, queryString, client);
                    return QueryBuilderHelper.CreateObject<Pokemon>(stringTask);
                }
            }
            catch (Exception ex)
            {
                return new Pokemon { Errors = new List<string> { ex.Message } };
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
                return new SetData { Errors = new List<string> { ex.Message } };
            }
        }

        public static async Task<SetData> GetSetsAsync(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;

                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = await QueryBuilderHelper.BuildTaskStringAsync(query, queryString, client);
                    return QueryBuilderHelper.CreateObject<SetData>(stringTask);
                }
            }
            catch (Exception ex)
            {
                return new SetData { Errors = new List<string> { ex.Message } };
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

        public static async Task<List<string>> GetSuperTypesAsync(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                var superTypes = new List<string>();
                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = await QueryBuilderHelper.BuildTaskStringAsync(null, queryString, client, ResourceTypes.SuperTypes);
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

        public static async Task<List<string>> GetTypesAsync(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                var superTypes = new List<string>();
                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = await QueryBuilderHelper.BuildTaskStringAsync(null, queryString, client, ResourceTypes.Types);
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

        public static async Task<List<string>> GetSubTypesAsync(Dictionary<string, string> query = null)
        {
            try
            {
                var queryString = string.Empty;
                var superTypes = new List<string>();
                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = await QueryBuilderHelper.BuildTaskStringAsync(null, queryString, client, ResourceTypes.SubTypes);
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

        public static async Task<T> FindAsync<T>(string id)
        {
            try
            {
                var type = QueryBuilderHelper.GetType<T>();

                using (var client = QueryBuilderHelper.SetupClient())
                {
                    var stringTask = await client.GetAsync($"{type}/{id}");
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