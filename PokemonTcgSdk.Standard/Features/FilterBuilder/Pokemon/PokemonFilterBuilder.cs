namespace PokemonTcgSdk.Standard.Features.FilterBuilder.Pokemon;

public static class PokemonFilterBuilder
{
    public static PokemonFilterCollection<string, string> CreatePokemonFilter()
    {
        return new PokemonFilterCollection<string, string>();
    }
}