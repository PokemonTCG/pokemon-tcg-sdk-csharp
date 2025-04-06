// Taken from PokeApiNet under MIT license

namespace PokemonTcgSdk.Standard.Infrastructure.HttpClients;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using Extensions;

/// <summary>
/// Based on https://source.dot.net/#Microsoft.AspNetCore.WebUtilities/QueryHelpers.cs,1c1b023fbf834a3d
/// </summary>
/// <remarks>
/// Once could opt for depending on https://www.nuget.org/packages/Microsoft.AspNetCore.WebUtilities/ instead of vendoring
/// the class in the library, but the nuget package contains a lot more than whats required in this lib.
/// </remarks>
internal static class QueryHelpers
{
    /// <summary>
    /// Append the given query keys and values to the URI.
    /// </summary>
    /// <param name="uri">The base URI.</param>
    /// <param name="queryString">A dictionary of query keys and values to append.</param>
    /// <returns>The combined result.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="uri"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="queryString"/> is <c>null</c>.</exception>
    public static string AddQueryString(string uri, Dictionary<string, string?> queryString)
    {
        if (uri == null)
        {
            throw new ArgumentNullException(nameof(uri));
        }

        if (queryString == null)
        {
            throw new ArgumentNullException(nameof(queryString));
        }

        return AddQueryString(uri, (IEnumerable<KeyValuePair<string, string?>>)queryString);
    }

    /// <summary>
    /// Append the given query keys and values to the URI.
    /// </summary>
    /// <param name="uri">The base URI.</param>
    /// <param name="queryString">A collection of name value query pairs to append.</param>
    /// <returns>The combined result.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="uri"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="queryString"/> is <c>null</c>.</exception>
    private static string AddQueryString(string uri, IEnumerable<KeyValuePair<string, string?>> queryString)
    {
        if (uri == null)
        {
            throw new ArgumentNullException(nameof(uri));
        }

        if (queryString == null)
        {
            throw new ArgumentNullException(nameof(queryString));
        }

        var uriToBeAppended = uri;
        var queryIndex = uriToBeAppended.IndexOf('?');
        var hasQuery = queryIndex != -1;

        var sb = new StringBuilder();
        sb.Append(uriToBeAppended);
        foreach (var parameter in queryString)
        {
            if (parameter.Value == null)
            {
                continue;
            }

            sb.Append(hasQuery ? '&' : '?');
            sb.Append(UrlEncoder.Default.Encode(parameter.Key));
            sb.Append('=');
            sb.Append(UrlEncoder.Default.Encode(parameter.Value));
            hasQuery = true;
        }

        return sb.ToString();
    }

    /// <summary>
    /// Append the given query keys and values to the URI.
    /// </summary>
    /// <param name="uri">The base URI.</param>
    /// <param name="queryString">A collection of name value query pairs to append.</param>
    /// <param name="filterQuery">A collection of name value filter pairs to append.</param>
    /// <returns>The combined result.</returns>
    /// <exception cref="ArgumentNullException">Thrown when any parameter is null.</exception>
    public static string AddQueryFiltersString(string uri, IDictionary<string, string> queryString, IDictionary<string, string> filterQuery)
    {
        ValidateParameters(uri, queryString, filterQuery);

        var sb = new StringBuilder(uri);
        var hasQuery = uri.Contains('?');

        AppendQueryParameters(sb, queryString, ref hasQuery);
        AppendFilterParameters(sb, filterQuery, ref hasQuery);
        AppendOrderByParameters(sb, filterQuery, hasQuery);

        return sb.ToString();
    }

    private static void ValidateParameters(string uri, IDictionary<string, string> queryString, IDictionary<string, string> filterQuery)
    {
        if (uri == null) throw new ArgumentNullException(nameof(uri));
        if (queryString == null) throw new ArgumentNullException(nameof(queryString));
        if (filterQuery == null) throw new ArgumentNullException(nameof(filterQuery));
    }

    private static void AppendQueryParameters(StringBuilder sb, IDictionary<string, string> queryString, ref bool hasQuery)
    {
        foreach (var parameter in queryString.Where(p => p.Value != null))
        {
            sb.Append(hasQuery ? '&' : '?')
                .Append(UrlEncoder.Default.Encode(parameter.Key))
                .Append('=')
                .Append(UrlEncoder.Default.Encode(parameter.Value));
            hasQuery = true;
        }
    }

    private static void AppendFilterParameters(StringBuilder sb, IDictionary<string, string> filterQuery, ref bool hasQuery)
    {
        var filters = filterQuery.Where(x => x.Key != "orderby" && x.Key != "thenby" && x.Value != null).ToList();

        if (!filters.Any()) return;

        sb.Append(hasQuery ? '&' : '?')
            .Append("q=");

        var isFirstFilter = true;
        foreach (var filter in filters)
        {
            if (!isFirstFilter)
            {
                sb.Append(' ');
            }

            AppendFilterValue(sb, filter.Key, filter.Value);
            isFirstFilter = false;
        }
    }

    private static void AppendFilterValue(StringBuilder sb, string key, string value)
    {
        var values = value.Split(',');

        if (values.Length > 1)
        {
            AppendMultiValueFilter(sb, key, values);
        }
        else
        {
            AppendSingleValueFilter(sb, key, value);
        }
    }

    private static void AppendMultiValueFilter(StringBuilder sb, string key, string[] values)
    {
        for (var i = 0; i < values.Length; i++)
        {
            sb.Append(UrlEncoder.Default.Encode(key))
                .Append(':')
                .Append(UrlEncoder.Default.Encode(values[i].HasSpaces()));

            if (i < values.Length - 1)
            {
                sb.Append(UrlEncoder.Default.Encode(" or "));
            }
        }
    }

    private static void AppendSingleValueFilter(StringBuilder sb, string key, string value)
    {
        sb.Append(UrlEncoder.Default.Encode(key))
            .Append(':')
            .Append(UrlEncoder.Default.Encode(value.HasSpaces()));
    }

    private static void AppendOrderByParameters(StringBuilder sb, IDictionary<string, string> filterQuery, bool hasQuery)
    {
        var orders = filterQuery.Where(x => (x.Key == "orderby" || x.Key == "thenby") && x.Value != null).ToList();

        if (!orders.Any()) return;

        sb.Append(hasQuery ? '&' : '?')
            .Append(UrlEncoder.Default.Encode("orderBy"))
            .Append('=');

        sb.Append(string.Join(",", orders.Select(o => UrlEncoder.Default.Encode(o.Value))));
    }
}