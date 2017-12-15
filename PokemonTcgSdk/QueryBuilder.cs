using PokemonTcgSdk.Helpers;
using PokemonTcgSdk.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace PokemonTcgSdk
{
    public class QueryBuilder
    {
        public static T Get<T>(Dictionary<string, string> query = null)
        {
            try
            {
                string queryString = string.Empty;
                HttpResponseMessage stringTask;
                string type = QueryBuilderHelper.GetType<T>(ref query);

                using (HttpClient client = QueryBuilderHelper.SetupClient())
                {
                    stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, type, client);
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
                string queryString = string.Empty;
                HttpResponseMessage stringTask;

                using (HttpClient client = QueryBuilderHelper.SetupClient())
                {
                    stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client);
                    return QueryBuilderHelper.CreateObject<Pokemon>(stringTask);
                }
            }
            catch (Exception ex)
            {
                Pokemon pokemon = new Pokemon();
                pokemon.Errors = new List<string>() { ex.Message };
                return pokemon;
            }
        }

        public static SetData GetSets(Dictionary<string, string> query = null)
        {
            try
            {
                string queryString = string.Empty;
                HttpResponseMessage stringTask;

                using (HttpClient client = QueryBuilderHelper.SetupClient())
                {
                    stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client);
                    return QueryBuilderHelper.CreateObject<SetData>(stringTask);
                }
            }
            catch (Exception ex)
            {
                SetData set = new SetData();
                set.Errors = new List<string>() { ex.Message };
                return set;
            }
        }

        public static List<string> GetSuperTypes(Dictionary<string, string> query = null)
        {
            try
            {
                string queryString = string.Empty;
                HttpResponseMessage stringTask;
                List<string> superTypes = new List<string>();
                query = QueryBuilderHelper.GetDefaultQuery(query);

                using (HttpClient client = QueryBuilderHelper.SetupClient())
                {
                    stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client, ResourceTypes.SuperTypes);
                    SuperType type = QueryBuilderHelper.CreateObject<SuperType>(stringTask);
                    superTypes.AddRange(type.Types);
                    return superTypes;
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>() { ex.Message };
                return errors;
            }
        }

        public static List<string> GetTypes(Dictionary<string, string> query = null)
        {
            try
            {
                string queryString = string.Empty;
                HttpResponseMessage stringTask;
                List<string> superTypes = new List<string>();
                query = QueryBuilderHelper.GetDefaultQuery(query);

                using (HttpClient client = QueryBuilderHelper.SetupClient())
                {
                    stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client, ResourceTypes.Types);
                    TypeData type = QueryBuilderHelper.CreateObject<TypeData>(stringTask);
                    superTypes.AddRange(type.Types);
                    return superTypes;
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>() { ex.Message };
                return errors;
            }
        }

        public static List<string> GetSubTypes(Dictionary<string, string> query = null)
        {
            try
            {
                string queryString = string.Empty;
                HttpResponseMessage stringTask;
                List<string> superTypes = new List<string>();
                query = QueryBuilderHelper.GetDefaultQuery(query);

                using (HttpClient client = QueryBuilderHelper.SetupClient())
                {
                    stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client, ResourceTypes.SubTypes);
                    SubType type = QueryBuilderHelper.CreateObject<SubType>(stringTask);
                    superTypes.AddRange(type.Types);
                    return superTypes;
                }
            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>() { ex.Message };
                return errors;
            }
        }

        public static T Find<T>(string id)
        {
            try
            {
                string type = QueryBuilderHelper.GetType<T>();

                using (HttpClient client = QueryBuilderHelper.SetupClient())
                {
                    HttpResponseMessage stringTask = client.GetAsync($"{type}/{id}").Result;
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
