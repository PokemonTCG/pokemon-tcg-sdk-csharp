namespace PokemonTcgSdk.Standard.Features.FilterBuilder.Trainer;

public static class TrainerFilterBuilder
{
    public static TrainerFilterCollection<string, string> CreateSetFilter()
    {
        return new TrainerFilterCollection<string, string>();
    }
}