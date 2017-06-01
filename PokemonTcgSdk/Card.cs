using PokemonTcgSdk.Helpers;
using PokemonTcgSdk.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace PokemonTcgSdk
{
    public class Card
    {
        /// <summary>
        /// Gets cards based on the query provided or a default list of cards.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static T Get<T>(Dictionary<string, string> query = null)
        {
            return QueryBuilder.Get<T>(query);
        }

        /// <summary>
        /// Gets the default list of cards or filter with a query.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static Pokemon Get(Dictionary<string, string> query = null)
        {
            try
            {
                // Make sure this actually gets the default cards
                // from the API as described.
                query = QueryBuilderHelper.GetDefaultQuery(query);

                Pokemon pokemon = QueryBuilder.GetPokemonCards(query);
                if (pokemon == null)
                {
                    pokemon.Errors = new List<string>() { "Not Found" };
                    return pokemon;
                }
                else
                {
                    return pokemon;
                }
            }
            catch (Exception ex)
            {
                Pokemon pokemon = new Pokemon();
                pokemon.Errors = new List<string>() { ex.Message };
                return pokemon;
            }
        }

        /// <summary>
        /// Find a card based on the id provided.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public static T Find<T>(string id)
        {
            return QueryBuilder.Find<T>(id);
        }

        /// <summary>
        /// Get all of the cards. This call will take a while to finish.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        // TODO: Make this call more generic
        public static List<PokemonCard> All(Dictionary<string, string> query = null)
        {
            using (HttpClient client = QueryBuilderHelper.SetupClient())
            {
                HttpResponseMessage stringTask;
                List<Pokemon> items = new List<Pokemon>();
                List<PokemonCard> mergedList = new List<PokemonCard>();
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
                        { CardQueryTypes.PageSize, "500" }
                    };
                }

                for (int i = 0; i < int.Parse(query[CardQueryTypes.PageSize]); i++)
                {
                    string queryString = string.Empty;
                    stringTask = QueryBuilderHelper.BuildTaskString(query, ref queryString, client, ResourceTypes.Cards);
                    if (stringTask.IsSuccessStatusCode)
                    {
                        Pokemon item = QueryBuilderHelper.CreateObject<Pokemon>(stringTask);
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
                foreach (Pokemon pokemon in items)
                {
                    mergedList.AddRange(pokemon.Cards);
                }

                return mergedList;
            }
        }
    }
}