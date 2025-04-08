namespace PokemonTcgSdk.Standard.Features.FilterBuilder.Base;

using Ordering;

public static class BaseFilter
{
    private const string OrderByKey = "orderby";
    private const string ThenByKey = "thenby";

    public static TCollection AddOrUpdate<TCollection>(TCollection dictionary, string key, string value) 
        where TCollection : BaseFilterCollection<string, string>
    {
        if (dictionary.TryGetValue(key, out var oldValue))
        {
            oldValue = $"{oldValue},{value}";
            dictionary[key] = oldValue;
            return dictionary;
        }

        dictionary.Add(key, value);
        return dictionary;
    }

    public static OrderedCardFilterCollection<TCollection, string, string> ThenBy<TCollection>(this OrderedCardFilterCollection<TCollection, string, string> dictionary, string value, Ordering ordering = 0)
        where TCollection : BaseFilterCollection<string, string>
    {
        if (ordering == Ordering.Descending)
        {
            value = $"-{value}";
        }

        if (dictionary.TryGetOrderingValue(ThenByKey, out var existingThenBy))
        {
            dictionary.SetOrderingValue(ThenByKey, $"{existingThenBy},{value}");
        }
        else
        {
            dictionary.SetOrderingValue(ThenByKey, value);
        }
        return dictionary;
    }
}