namespace PokemonTcgSdk.Standard.Features.FilterBuilder.Trainer;

using Infrastructure.HttpClients.Cards;

public static class TrainerFilter
{
    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Double Rainbow Energy" or "Heal Energy"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static TrainerFilterCollection<string, string> AddName(this TrainerFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(EnergyCard.Name), value);
    }

    private static TrainerFilterCollection<string, string> AddOrUpdate(TrainerFilterCollection<string, string> dictionary, string key, string value)
    {
        if (dictionary.TryGetValue(key, out var oldValue))
        {
            oldValue = $"{oldValue} or {value}";
            dictionary[key] = oldValue;
            return dictionary;
        }

        dictionary.Add(key, value);
        return dictionary;
    }
}