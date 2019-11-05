using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PokemonTcgSdk.Helpers;
using PokemonTcgSdk.Mappers;
using PokemonTcgSdk.Models;

namespace PokemonTcgSdk
{
    public class Card
    {
        /// <summary>
        ///     Gets cards based on the query provided or a default list of cards.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static async Task<T> Get<T>(Dictionary<string, string> query = null)
        {
            return await QueryBuilder.Get<T>(query);
        }

        /// <summary>
        ///     Gets the default list of cards or filter with a query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static async Task<Pokemon> Get(Dictionary<string, string> query = null)
        {
            try
            {
                var pokemon = await QueryBuilder.GetPokemonCards(query);
                return pokemon ?? new Pokemon { Errors = new List<string> { "Not Found" } };
            }
            catch (Exception ex)
            {
                return new Pokemon
                {
                    Errors = new List<string> { ex.Message }
                };
            }
        }

        /// <summary>
        ///     Find a card based on the id provided.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T Find<T>(string id)
        {
            return QueryBuilder.Find<T>(id);
        }

        /// <summary>
        ///     Get all of the cards. This call will take a while to finish.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static async Task<List<PokemonCard>> All(Dictionary<string, string> query = null)
        {
            using (var client = QueryBuilderHelper.SetupClient())
            {
                var items = new List<Pokemon>();
                var mergedList = new List<PokemonCard>();
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
                        {CardQueryTypes.PageSize, "500"}
                    };
                }

                var totalCount = int.Parse(query[CardQueryTypes.PageSize]);
                int amount;
                for (var i = 0; i < totalCount; i += amount)
                {
                    var queryString = string.Empty;
                    var stringTask =
                        await QueryBuilderHelper.BuildTaskString(query, queryString, client, ResourceTypes.Cards);
                    if (stringTask.IsSuccessStatusCode)
                    {
                        var info = HttpResponseToPagingInfo.MapFrom(stringTask.Headers);
                        totalCount = info.TotalCount;
                        amount = info.Count;

                        var item = QueryBuilderHelper.CreateObject<Pokemon>(stringTask);
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
                foreach (var pokemon in items) mergedList.AddRange(pokemon.Cards);

                return mergedList;
            }
        }
    }
}