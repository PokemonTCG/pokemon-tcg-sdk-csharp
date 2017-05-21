using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace PokemonTcgSdk.Helpers
{
    public class QueryBuilderHelper
    {
        public static HttpClient SetupClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(Config.Endpoint);
            return client;
        }

        public static string GetType<T>(ref Dictionary<string, string> query)
        {
            string type;
            switch (typeof(T).Name)
            {
                case "Pokemon":
                    type = ResourceTypes.Cards;
                    break;
                case "Trainer":
                    type = ResourceTypes.Cards;
                    if (query != null)
                    {
                        query.Add("supertype", "trainer");
                    }
                    else
                    {
                        query = new Dictionary<string, string>
                        {
                            { "supertype", "trainer" }
                        };
                    }
                    break;
                case "TypeData":
                    type = ResourceTypes.Types;
                    break;
                case "SetData":
                    type = ResourceTypes.Sets;
                    break;
                case "SubType":
                    type = ResourceTypes.SubTypes;
                    break;
                case "SuperType":
                    type = ResourceTypes.SuperTypes;
                    break;
                default:
                    type = ResourceTypes.Cards;
                    break;
            }

            return type;
        }

        public static string GetType<T>()
        {
            string type;
            switch (typeof(T).Name)
            {
                case "Pokemon":
                case "Trainer":
                    type = ResourceTypes.Cards;
                    break;
                case "TypeData":
                    type = ResourceTypes.Types;
                    break;
                case "SetData":
                    type = ResourceTypes.Sets;
                    break;
                case "SubType":
                    type = ResourceTypes.SubTypes;
                    break;
                case "SuperType":
                    type = ResourceTypes.SuperTypes;
                    break;
                default:
                    type = ResourceTypes.Cards;
                    break;
            }

            return type;
        }

        public static HttpResponseMessage BuildTaskString(Dictionary<string, string> query, ref string queryString, HttpClient client, string type = "cards")
        {
            HttpResponseMessage stringTask;
            if (query != null && query.Any())
            {
                var lastItem = query.Values.Last();
                foreach (KeyValuePair<string, string> item in query)
                {
                    queryString += $"{item.Key}={item.Value}";

                    if (lastItem != item.Value)
                    {
                        queryString += "&";
                    }
                }

                stringTask = client.GetAsync($"{type}?{queryString}").Result;
            }
            else
            {
                stringTask = client.GetAsync(type).Result;
            }

            return stringTask;
        }

        public static HttpResponseMessage BuildTaskString(Dictionary<string, string> query, ref string queryString, string type, HttpClient client)
        {
            HttpResponseMessage stringTask;
            queryString = string.Empty;
            if (query != null && query.Any())
            {
                var lastItem = query.Values.Last();
                foreach (KeyValuePair<string, string> item in query)
                {
                    queryString += $"{item.Key}={item.Value}";

                    if (lastItem != item.Value)
                    {
                        queryString += "&";
                    }
                }

                stringTask = client.GetAsync($"{type}?{queryString}").Result;
            }
            else
            {
                stringTask = client.GetAsync(type).Result;
            }

            return stringTask;
        }

        public static T CreateObject<T>(HttpResponseMessage stringTask)
        {
            HttpContent result = stringTask.Content;
            string data = result.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(data);
        }

        public static bool FetchAll(ref Dictionary<string, string> query)
        {
            if (query != null)
            {
                if (query.ContainsKey(CardQueryTypes.Page))
                {
                    return false;
                }
            }

            return true;
        }

        public static Dictionary<string, string> GetDefaultQuery(Dictionary<string, string> query)
        {
            if (query != null)
            {
                query = null;
            }

            return query;
        }
    }
}
