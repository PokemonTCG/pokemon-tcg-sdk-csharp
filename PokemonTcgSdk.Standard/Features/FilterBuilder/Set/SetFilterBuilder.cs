namespace PokemonTcgSdk.Standard.Features.FilterBuilder.Set;

public static class SetFilterBuilder
{
    public static SetFilterCollection<string, string> CreateSetFilter()
    {
        return new SetFilterCollection<string, string>();
    }
}
