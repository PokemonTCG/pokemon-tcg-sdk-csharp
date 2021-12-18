using System.Collections.Generic;
using System.Linq;

namespace PokemonTcgSdkV2.Utils.Query
{
    /// <summary>
    ///     A utility class to easily build a search query.
    /// </summary>
    public class QueryBuilder
    {
        private Dictionary<string, List<string>> QueryEntries { get; } = new Dictionary<string, List<string>>();

        /// <summary>
        ///     Starts building a new search query.
        /// </summary>
        /// <param name="key">Key to search for.</param>
        /// <param name="value">Value to search for.</param>
        /// <returns>A new search query instance ready to use or to extend with more filters.</returns>
        public static QueryBuilder StartQuery(string key, string value)
        {
            var queryBuilder = new QueryBuilder();
            queryBuilder.Add(key, value);

            return queryBuilder;
        }

        /// <summary>
        ///     Adds a new search filter.
        /// </summary>
        /// <param name="key">Key to search for.</param>
        /// <param name="value">Value to search for.</param>
        /// <returns></returns>
        public QueryBuilder Add(string key, string value)
        {
            if (!QueryEntries.ContainsKey(key)) QueryEntries.Add(key, new List<string>());

            QueryEntries[key].Add(value);

            return this;
        }

        private string EscapeValue(string value)
        {
            value = value.Replace(@"""", ""); // Remove quotations

            if (value.Contains(" ")) value = @"""" + value + @"""";

            return value;
        }

        /// <summary>
        ///     Builds the query string from configured filters.
        /// </summary>
        /// <returns>Query string.</returns>
        public string BuildQuery()
        {
            var query = QueryEntries.Keys.Where(queryEntriesKey => QueryEntries[queryEntriesKey].Count != 0).Aggregate(
                "",
                (current, queryEntriesKey) =>
                    current +
                    $"({string.Join(" OR ", QueryEntries[queryEntriesKey].Select(s => $"{queryEntriesKey}:{EscapeValue(s)}"))}) ");

            return query.Trim();
        }
    }
}