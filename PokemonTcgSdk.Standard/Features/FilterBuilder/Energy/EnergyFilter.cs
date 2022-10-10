namespace PokemonTcgSdk.Standard.Features.FilterBuilder.Energy;

using Infrastructure.HttpClients.Cards;

public static class EnergyFilter
{
    /// <summary>
    /// Extension method. Will add new id filter. If id filter exists
    /// will concat and create an OR filter. e.g "dp4-3" or "dp4-4"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static EnergyFilterCollection<string, string> AddId(this EnergyFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(EnergyCard.Id).ToLower(), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Double Rainbow Energy" or "Heal Energy"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static EnergyFilterCollection<string, string> AddName(this EnergyFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(EnergyCard.Name).ToLower(), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Dark" or "Water"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static EnergyFilterCollection<string, string> AddSubTypes(this EnergyFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(EnergyCard.Subtypes).ToLower(), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Dark" or "Water"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static EnergyFilterCollection<string, string> AddSetName(this EnergyFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, $"{nameof(EnergyCard.Set).ToLower()}.{nameof(EnergyCard.Set.Name).ToLower()}", value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Dark" or "Water"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static EnergyFilterCollection<string, string> AddSetSeries(this EnergyFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, $"{nameof(EnergyCard.Set).ToLower()}.{nameof(EnergyCard.Set.Series).ToLower()}", value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Dark" or "Water"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static EnergyFilterCollection<string, string> AddRarity(this EnergyFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(EnergyCard.Rarity).ToLower(), value);
    }

    private static EnergyFilterCollection<string, string> AddOrUpdate(EnergyFilterCollection<string, string> dictionary, string key, string value)
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