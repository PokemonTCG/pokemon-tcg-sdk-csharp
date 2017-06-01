using PokemonTcgSdk.Helpers;
using PokemonTcgSdk.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace PokemonTcgSdk
{
    public class Sets
    {
        public static SetData Get()
        {
            return QueryBuilder.GetSets();
        }

        public static List<SetData> Find(Dictionary<string, string> query)
        {
            string queryString = string.Empty;
            using (HttpClient client = QueryBuilderHelper.SetupClient())
            {
                HttpResponseMessage stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client, ResourceTypes.Sets);
                Set set = QueryBuilderHelper.CreateObject<Set>(stringTask);

                return set.Cards;
            }
        }

        // TODO: Make this call more generic
        public static List<SetData> All(Dictionary<string, string> query = null)
        {
            using (HttpClient client = QueryBuilderHelper.SetupClient())
            {
                HttpResponseMessage stringTask;
                List<Set> items = new List<Set>();
                List<SetData> mergedList = new List<SetData>();
                bool fetchAll = QueryBuilderHelper.FetchAll(ref query);

                if (query != null)
                {
                    if (!query.ContainsKey(CardQueryTypes.Page))
                    {
                        query.Add(CardQueryTypes.Page, "1");
                    }
                    query.Add(CardQueryTypes.PageSize, "500");
                }
                else
                {
                    query = new Dictionary<string, string>()
                    {
                        { CardQueryTypes.Page, "1" },
                        { CardQueryTypes.PageSize, "100" }
                    };
                }

                for (int i = 0; i < 1; i++)
                {
                    string queryString = string.Empty;
                    stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client, ResourceTypes.Sets);
                    if (stringTask.IsSuccessStatusCode)
                    {
                        Set item = QueryBuilderHelper.CreateObject<Set>(stringTask);
                        query[CardQueryTypes.Page] = (int.Parse(query[CardQueryTypes.Page]) + 1).ToString();
                        items.Add(item);

                        if (!fetchAll)
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                // Create the list returned as a single list instead of
                // a list of lists
                foreach (Set set in items)
                {
                    mergedList.AddRange(set.Cards);
                }

                return mergedList;
            }
        }
    }
}
