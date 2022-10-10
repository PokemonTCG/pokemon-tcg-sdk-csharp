namespace PokemonTcgSdk.Standard.Features.FilterBuilder.Trainer;

using Infrastructure.HttpClients.Cards;

// TODO: Legalities
public static class TrainerFilter
{
    /// <summary>
    /// Extension method. Will add new id filter. If id filter exists
    /// will concat and create an OR filter. e.g "dp4-3" or "dp4-4"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static TrainerFilterCollection<string, string> AddId(this TrainerFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(TrainerCard.Id).ToLower(), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Double Rainbow Energy" or "Heal Energy"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static TrainerFilterCollection<string, string> AddName(this TrainerFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(TrainerCard.Name).ToLower(), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Base" or "Plasma Blast"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static TrainerFilterCollection<string, string> AddSetName(this TrainerFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, $"{nameof(TrainerCard.Set).ToLower()}.{nameof(TrainerCard.Set.Name).ToLower()}", value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Black & White" or "Base"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static TrainerFilterCollection<string, string> AddSetSeries(this TrainerFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, $"{nameof(TrainerCard.Set).ToLower()}.{nameof(TrainerCard.Set.Series).ToLower()}", value);
    }

    private static TrainerFilterCollection<string, string> AddOrUpdate(TrainerFilterCollection<string, string> dictionary, string key, string value)
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