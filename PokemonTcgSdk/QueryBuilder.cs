using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokemonTcgSdk.Models;

namespace PokemonTcgSdk
{
    public static class QueryBuilder
    {
        public static T Get<T>(string type, Dictionary<string, string> args = null)
        {
            var argString = string.Empty;
            HttpResponseMessage stringTask;

            using (HttpClient client = new HttpClient())
            {
                SetupClient(client);
                if (args != null && args.Any())
                {
                    var lastItem = args.Values.Last();
                    foreach (KeyValuePair<string, string> item in args)
                    {
                        argString += item.Key + "=" + item.Value;

                        if (lastItem != item.Value)
                        {
                            argString += "&";
                        }
                    }

                    stringTask = client.GetAsync(type + "?" + argString).Result;
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

        public static T Find<T>(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                SetupClient(client);
                HttpResponseMessage stringTask = client.GetAsync($"cards/{id}").Result;
                HttpContent result = stringTask.Content;

                string data = result.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(data);
            }
        }

        private static void SetupClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(Config.Endpoint);
        }
    }
}
