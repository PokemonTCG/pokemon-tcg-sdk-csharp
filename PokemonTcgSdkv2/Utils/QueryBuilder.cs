using System.Collections.Generic;
using System.Linq;

namespace PokemonTcgSdkV2.Utils
{
    public class QueryBuilder
    {
        private Dictionary<string, List<string>> QueryEntries { get; } = new Dictionary<string, List<string>>();

        public static QueryBuilder StartQuery(string key, string value)
        {
            var queryBuilder = new QueryBuilder();
            queryBuilder.Add(key, value);

            return queryBuilder;
        }

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

        public string BuildQuery()
        {
            var query = QueryEntries.Keys.Where(queryEntriesKey => QueryEntries[queryEntriesKey].Count != 0).Aggregate(
                "",
                (current, queryEntriesKey) =>
                    current +
                    $"({string.Join(" OR ", QueryEntries[queryEntriesKey].Select(s => $"{queryEntriesKey}:{EscapeValue(s)}"))})");

            return query.Trim();
        }
    }
}