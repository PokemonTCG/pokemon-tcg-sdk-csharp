namespace PokemonTcgSdk.Standard.Features.FilterBuilder.Set;

using Infrastructure.HttpClients.Set;

// TODO: Legalities Filters
public static class SetFilter
{
    /// <summary>
    /// Extension method. Will add new id filter. If id filter exists
    /// will concat and create an OR filter. e.g "dp4-3" or "dp4-4"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static SetFilterCollection<string, string> AddId(this SetFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(Set.Id).ToLower(), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Mew" or "Mewtwo"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static SetFilterCollection<string, string> AddName(this SetFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(Set.Name), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Mew" or "Mewtwo"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static SetFilterCollection<string, string> AddSeries(this SetFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(Set.Series), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Mew" or "Mewtwo"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static SetFilterCollection<string, string> AddPtcgoCode(this SetFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(Set.PtcgoCode), value);
    }

    private static SetFilterCollection<string, string> AddOrUpdate(SetFilterCollection<string, string> dictionary, string key, string value)
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
}