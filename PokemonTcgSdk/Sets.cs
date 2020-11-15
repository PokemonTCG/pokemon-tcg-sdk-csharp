﻿using PokemonTcgSdk.Helpers;
using PokemonTcgSdk.Mappers;
using PokemonTcgSdk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PokemonTcgSdk
{
    public class Sets
    {
        public static SetData Get()
        {
            return QueryBuilder.GetSets();
        }

        public static async Task<SetData> GetAsync()
        {
            return await QueryBuilder.GetSetsAsync();
        }

        public static List<SetData> Find(Dictionary<string, string> query)
        {
            var queryString = string.Empty;
            using (var client = QueryBuilderHelper.SetupClient())
            {
                var stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client, ResourceTypes.Sets);
                var set = QueryBuilderHelper.CreateObject<Set>(stringTask);

                return set.Cards;
            }
        }

        public static async Task<List<SetData>> FindAsync(Dictionary<string, string> query)
        {
            var queryString = string.Empty;
            using (var client = QueryBuilderHelper.SetupClient())
            {
                var stringTask = await QueryBuilderHelper.BuildTaskStringAsync(query, queryString, client, ResourceTypes.Sets);
                var set = QueryBuilderHelper.CreateObject<Set>(stringTask);

                return set.Cards;
            }
        }

        public static List<SetData> All(Dictionary<string, string> query = null)
        {
            using (var client = QueryBuilderHelper.SetupClient())
            {
                var items = new List<Set>();
                var mergedList = new List<SetData>();
                var fetchAll = QueryBuilderHelper.FetchAll(ref query);

                if (query != null)
                {
                    if (!query.ContainsKey(CardQueryTypes.Page)) query.Add(CardQueryTypes.Page, "1");
                    query.Add(CardQueryTypes.PageSize, "500");
                }
                else
                {
                    query = new Dictionary<string, string>
                    {
                        {CardQueryTypes.Page, "1"},
                        {CardQueryTypes.PageSize, "100"}
                    };
                }

                var totalCount = int.Parse(query[CardQueryTypes.PageSize]);
                int amount;
                for (var i = 0; i < totalCount; i += amount)
                {
                    var queryString = string.Empty;
                    var stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client, ResourceTypes.Sets);
                    if (stringTask.IsSuccessStatusCode)
                    {
                        var info = HttpResponseToPagingInfo.MapFrom(stringTask.Headers);
                        totalCount = info.TotalCount;
                        amount = info.Count;

                        var item = QueryBuilderHelper.CreateObject<Set>(stringTask);
                        query[CardQueryTypes.Page] = (int.Parse(query[CardQueryTypes.Page]) + 1).ToString();
                        items.Add(item);

                        if (!fetchAll) break;
                    }
                    else
                    {
                        break;
                    }
                }

                // Create the list returned as a single list instead of a list of lists
                foreach (var set in items) mergedList.AddRange(set.Cards);

                return mergedList;
            }
        }

        public static async Task<List<SetData>> AllAsync(Dictionary<string, string> query = null)
        {
            using (var client = QueryBuilderHelper.SetupClient())
            {
                var items = new List<Set>();
                var mergedList = new List<SetData>();
                var fetchAll = QueryBuilderHelper.FetchAll(ref query);

                if (query != null)
                {
                    if (!query.ContainsKey(CardQueryTypes.Page)) query.Add(CardQueryTypes.Page, "1");
                    query.Add(CardQueryTypes.PageSize, "500");
                }
                else
                {
                    query = new Dictionary<string, string>
                    {
                        {CardQueryTypes.Page, "1"},
                        {CardQueryTypes.PageSize, "100"}
                    };
                }

                var totalCount = int.Parse(query[CardQueryTypes.PageSize]);
                int amount;
                for (var i = 0; i < totalCount; i += amount)
                {
                    var queryString = string.Empty;
                    var stringTask = await QueryBuilderHelper.BuildTaskStringAsync(query, queryString, client, ResourceTypes.Sets);
                    if (stringTask.IsSuccessStatusCode)
                    {
                        var info = HttpResponseToPagingInfo.MapFrom(stringTask.Headers);
                        totalCount = info.TotalCount;
                        amount = info.Count;

                        var item = QueryBuilderHelper.CreateObject<Set>(stringTask);
                        query[CardQueryTypes.Page] = (int.Parse(query[CardQueryTypes.Page]) + 1).ToString();
                        items.Add(item);

                        if (!fetchAll) break;
                    }
                    else
                    {
                        break;
                    }
                }

                // Create the list returned as a single list instead of a list of lists
                foreach (var set in items) mergedList.AddRange(set.Cards);

                return mergedList;
            }
        }
    }
}