namespace PokemonTcgSdk.Standard.Features.FilterBuilder.Energy;

public class EnergyFilterBuilder
{
    public static EnergyFilterCollection<string, string> CreateEnergyFilter()
    {
        return new EnergyFilterCollection<string, string>();
    }
}