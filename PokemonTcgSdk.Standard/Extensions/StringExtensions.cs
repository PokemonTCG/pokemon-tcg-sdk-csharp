namespace PokemonTcgSdk.Standard.Extensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class StringExtensions
{
    public static int ToInt(this string source) => int.TryParse(source, out var number) ? number : 0;

    public static decimal ToDecimal(this string source) => decimal.TryParse(source, out var number) ? number : 0;

    public static bool ToBool(this string source) => bool.TryParse(source, out var value) && value;

    public static string Append(this string text, string addedText)
    {
        var builder = new StringBuilder(text);
        builder.AppendLine(addedText);

        return builder.ToString();
    }

    public static string WithFallback(this string primaryString, string secondaryString) => string.IsNullOrWhiteSpace(primaryString) ? secondaryString : primaryString;

    public static string JoinStrings(this IEnumerable<string> input, string delimiter = ", ")
    {
        return input == null ? null : string.Join(delimiter, input.Where(x => x.IsNotEmpty()));
    }

    public static bool IsNotEmpty(this string str)
    {
        return !IsEmpty(str);
    }

    public static bool IsEmpty(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    public static string DefaultIfEmpty(this string str, string defaultValue)
    {
        return str.IsNotEmpty() ? str : defaultValue;
    }

    public static string[] SafeSplit(this string input, params string[] separators)
    {
        return input.IsEmpty() ? new string[0] : input.Split(separators, StringSplitOptions.None);
    }

    public static string HasSpaces(this string str)
    {
        if (str.Any(char.IsWhiteSpace) && !str.Contains("TO"))
        {
            return $"\"{str}\"";
        }

        return str;
    }
}