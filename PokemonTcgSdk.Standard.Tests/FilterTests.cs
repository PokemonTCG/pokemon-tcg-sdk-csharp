namespace PokemonTcgSdk.Standard.Tests;

using Features.FilterBuilder.Pokemon;
using Features.FilterBuilder.Set;
using NUnit.Framework;

public class FilterTests
{

    [Test]
    public void SetFilters_ReturnPopulatedDictionary()
    {
        // assemble
        var dicObj = new SetFilterCollection<string, string>
        {
            {"Name", "Darkness Ablaze"}
        };

        // act
        var filterBuilder = SetFilterBuilder.CreateSetFilter()
            .AddName("Darkness Ablaze");

        // assert
        Assert.That(filterBuilder, Is.EqualTo(dicObj));
    }

    [Test]
    public void SetFilters_ReturnMulitplePopulatedDictionary()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"Name", "Darkness Ablaze,Lost Origins"}
        };

        // act
        var filterBuilder = SetFilterBuilder.CreateSetFilter()
            .AddName("Darkness Ablaze")
            .AddName("Lost Origins");

        // assert
        Assert.That(filterBuilder, Is.EqualTo(dicObj));
    }

    [Test]
    public void PokemonFilter_Name()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"name", "Darkrai"}
        };

        // act
        var filterBuilder = PokemonFilterBuilder.CreatePokemonFilter()
            .AddName("Darkrai");

        // assert
        Assert.That(filterBuilder, Is.EqualTo(dicObj));
    }

    [Test]
    public void PokemonFilter_MultipleName()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"name", "Darkrai,Pikachu"}
        };

        // act
        var filterBuilder = PokemonFilterBuilder.CreatePokemonFilter()
            .AddName("Darkrai")
            .AddName("Pikachu");

        // assert
        Assert.That(filterBuilder, Is.EqualTo(dicObj));
    }

    [Test]
    public void PokemonFilter_Subtype()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"subtypes", "Stage 1"}
        };

        // act
        var filterBuilder = PokemonFilterBuilder.CreatePokemonFilter().AddSubTypes("Stage 1");

        // assert
        Assert.That(filterBuilder, Is.EqualTo(dicObj));
    }

    [Test]
    public void PokemonFilter_HpRange()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"hp", "{60 TO 120}"}
        };

        // act
        var filterBuilder = PokemonFilterBuilder.CreatePokemonFilter().AddHpRange("60", "120", false);

        // assert
        Assert.That(filterBuilder, Is.EqualTo(dicObj));
    }

    [Test]
    public void PokemonFilter_MultipleFilters()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"name", "Darkrai,Pikachu"},
            {"subtypes", "Stage 1"},
            {"hp", "{60 TO 120}"},
            {"rarity", "Common"},
            {"attacks.convertedEnergyCost", "{2 TO 4}"},
            {"evolvesfrom", "Pikachu"}
        };

        // act
        var filterBuilder = PokemonFilterBuilder.CreatePokemonFilter()
            .AddName("Darkrai")
            .AddName("Pikachu")
            .AddSubTypes("Stage 1")
            .AddHpRange("60", "120", false)
            .AddRarity("Common")
            .AddAttackCostRange("2", "4", false)
            .AddEvolvesFrom("Pikachu");

        // assert
        Assert.That(filterBuilder, Is.EqualTo(dicObj));
    }
}