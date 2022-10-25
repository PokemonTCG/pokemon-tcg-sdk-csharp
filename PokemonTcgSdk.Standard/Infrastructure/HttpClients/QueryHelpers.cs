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
    /// <exception cref="ArgumentNullException"><paramref name="uri"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="queryString"/> is <c>null</c>.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="filterQuery"/> is <c>null</c>.</exception>
    public static string AddQueryFiltersString(string uri, IDictionary<string, string> queryString, IDictionary<string, string> filterQuery)
    {
        if (uri == null)
        {
            throw new ArgumentNullException(nameof(uri));
        }

        if (queryString == null)
        {
            throw new ArgumentNullException(nameof(queryString));
        }

        if (filterQuery == null)
        {
            throw new ArgumentNullException(nameof(filterQuery));
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

        if (filterQuery.Any())
        {
            sb.Append(hasQuery ? '&' : '?');
            sb.Append('q');
            sb.Append('=');
            hasQuery = false;
        }

        foreach (KeyValuePair<string, string> filterItem in filterQuery)
        {
            if (filterItem.Value == null)
            {
                continue;
            }

            if (hasQuery)
            {
                sb.Append(' ');
            }

            if (filterItem.Value.Split(',').Length > 0)
            {
                var split = filterItem.Value.Split(',');
                foreach (var item in split)
                {
                    sb.Append(UrlEncoder.Default.Encode(filterItem.Key));
                    sb.Append(':');
                    sb.Append(UrlEncoder.Default.Encode(item.HasSpaces()));
                    var orVlaue = " or ";
                    if (item != split.LastOrDefault())
                    {
                        sb.Append(UrlEncoder.Default.Encode(orVlaue));
                    }
                }

            }
            else
            {
                sb.Append(UrlEncoder.Default.Encode(filterItem.Key));
                sb.Append(':');
                sb.Append(UrlEncoder.Default.Encode(filterItem.Value.HasSpaces()));
            }

            hasQuery = true;
        }

        return sb.ToString();
    }
}