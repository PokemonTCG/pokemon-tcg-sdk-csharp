using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace PokemonTcgSdk
{
    public class QueryBuilder
    {
        public static T Get<T>(string type, Dictionary<string, string> args = null)
        {
            var argString = string.Empty;
            HttpResponseMessage stringTask;

            using (HttpClient client = SetupClient())
            {
                if (args != null && args.Any())
                {
                    var lastItem = args.Values.Last();
                    foreach (KeyValuePair<string, string> item in args)
                    {
                        argString += $"{item.Key}={item.Value}";

                        if (lastItem != item.Value)
                        {
                            argString += "&";
                        }
                    }

                    stringTask = client.GetAsync($"{type}?{argString}").Result;
                }
                else
                {
                    stringTask = client.GetAsync(type).Result;
                }

                HttpContent result = stringTask.Content;
                string data = result.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(data);
            }
        }

        public static T Find<T>(string type, string id)
        {
            using (HttpClient client = SetupClient())
            {
                HttpResponseMessage stringTask = client.GetAsync($"{type}/{id}").Result;
                HttpContent result = stringTask.Content;
                string data = result.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(data);
            }
        }

        private static HttpClient SetupClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(Config.Endpoint);
            return client;
        }
    }
}
