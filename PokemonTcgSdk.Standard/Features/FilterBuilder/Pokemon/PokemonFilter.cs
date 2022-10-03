namespace PokemonTcgSdk.Standard.Features.FilterBuilder.Pokemon;

using Infrastructure.HttpClients.Cards;

public static class PokemonFilter
{
    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Mew" or "Mewtwo"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static PokemonFilterCollection<string, string> AddName(this PokemonFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(PokemonCard.Name).ToLower(), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Stage 1" or "Basic"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static PokemonFilterCollection<string, string> AddSubTypes(this PokemonFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(PokemonCard.Subtypes).ToLower(), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "60 TO 120" or "60"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="lowValue">The low hp value to add to the filter</param>
    /// <param name="highValue">The high hp value to add to the filter</param>
    /// <param name="isInclusive">If false range filter will be exclusive. If true range filter will be inclusive</param>
    public static PokemonFilterCollection<string, string> AddHpRange(this PokemonFilterCollection<string, string> dictionary, string lowValue, string highValue, bool isInclusive)
    {
        if (isInclusive)
        {
            return AddOrUpdate(dictionary, nameof(PokemonCard.Hp).ToLower(), $"[{lowValue} TO {highValue}]");
        }

        return AddOrUpdate(dictionary, nameof(PokemonCard.Hp).ToLower(), $"{{{lowValue} TO {highValue}}}");
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Dark" or "Water"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static PokemonFilterCollection<string, string> AddTypes(this PokemonFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(PokemonCard.Types).ToLower(), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Flaaffy" or "Pikacu"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static PokemonFilterCollection<string, string> AddEvolvesFrom(this PokemonFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(PokemonCard.EvolvesFrom).ToLower(), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Dragonair" or "Metapod"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static PokemonFilterCollection<string, string> AddEvolvesTo(this PokemonFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(PokemonCard.EvolvesTo).ToLower(), value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Dragonair" or "Metapod"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="lowValue">The low attack cost value to add to the filter</param>
    /// <param name="highValue">The high attack cost value to add to the filter</param>
    /// <param name="isInclusive">If false range filter will be exclusive. If true range filter will be inclusive</param>
    public static PokemonFilterCollection<string, string> AddAttackCostRange(this PokemonFilterCollection<string, string> dictionary, string lowValue, string highValue, bool isInclusive)
    {
        if (isInclusive)
        {
            return AddOrUpdate(dictionary, $"{nameof(PokemonCard.Attacks).ToLower()}.convertedEnergyCost", $"[{lowValue} TO {highValue}]");
        }

        return AddOrUpdate(dictionary, $"{nameof(PokemonCard.Attacks).ToLower()}.convertedEnergyCost", $"{{{lowValue} TO {highValue}}}");
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Dark" or "Water"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static PokemonFilterCollection<string, string> AddSetName(this PokemonFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, $"{nameof(PokemonCard.Set).ToLower()}.{nameof(PokemonCard.Set.Name).ToLower()}", value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Dark" or "Water"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static PokemonFilterCollection<string, string> AddSetSeries(this PokemonFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, $"{nameof(PokemonCard.Set).ToLower()}.{nameof(PokemonCard.Set.Series).ToLower()}", value);
    }

    /// <summary>
    /// Extension method. Will add new name filter. If name filter exists
    /// will concat and create an OR filter. e.g "Dark" or "Water"
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="value">The name value to add</param>
    public static PokemonFilterCollection<string, string> AddRarity(this PokemonFilterCollection<string, string> dictionary, string value)
    {
        return AddOrUpdate(dictionary, nameof(PokemonCard.Rarity).ToLower(), value);
    }


    private static PokemonFilterCollection<string, string> AddOrUpdate(PokemonFilterCollection<string, string> dictionary, string key, string value)
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