namespace PokemonTcgSdk.Standard.Tests;

using Features.FilterBuilder.Base;
using Features.FilterBuilder.Ordering;
using Features.FilterBuilder.Pokemon;
using Features.FilterBuilder.Set;
using Features.FilterBuilder.Trainer;
using Infrastructure.HttpClients.CommonModels;
using NUnit.Framework;

public class FilterTests
{
    [Test]
    public void SetFilters_ReturnPopulatedDictionary()
    {
        // assemble
        var dicObj = new SetFilterCollection<string, string>
        {
            {"name", "Darkness Ablaze"}
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
            {"name", "Darkness Ablaze,Lost Origins"}
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

    [Test]
    public void PokemonFilter_HasMultipleAncientTraits()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"ancientTrait.name", Global.AncientTrait.Traits}
        };

        // act
        var filterBuilder = PokemonFilterBuilder.CreatePokemonFilter().HasAncientTrait().HasAncientTrait().HasAncientTrait();


        // assert
        Assert.That(filterBuilder, Is.EqualTo(dicObj));
    }

    [Test]
    public void PokemonFilter_OrderBy()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"name", "Darkrai"},
            {"orderby", "hp"},
        };

        // act
        var filterBuilder = PokemonFilterBuilder.CreatePokemonFilter().AddName("Darkrai").OrderBy("hp");
        var dictionary = new Dictionary<string, string>(filterBuilder);

        // assert
        Assert.That(dictionary, Is.EqualTo(dicObj));
    }

    [Test]
    public void PokemonFilter_OrderByDescending()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"name", "Darkrai"},
            {"orderby", "-hp"},
        };

        // act
        var filterBuilder = PokemonFilterBuilder.CreatePokemonFilter().AddName("Darkrai").OrderBy("hp", Ordering.Descending);
        var dictionary = new Dictionary<string, string>(filterBuilder);

        // assert
        Assert.That(dictionary, Is.EqualTo(dicObj));
    }

    [Test]
    public void PokemonFilter_OrderBy_ThenBy()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"name", "Darkrai"},
            {"orderby", "hp"},
            {"thenby", "id"},
        };

        // act
        var filterBuilder = PokemonFilterBuilder.CreatePokemonFilter().AddName("Darkrai").OrderBy("hp").ThenBy("id");
        var dictionary = new Dictionary<string, string>(filterBuilder);

        // assert
        Assert.That(dictionary, Is.EqualTo(dicObj));
    }

    [Test]
    public void PokemonFilter_OrderBy_ThenByDescending()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"name", "Darkrai"},
            {"orderby", "hp"},
            {"thenby", "-id"},
        };

        // act
        var filterBuilder = PokemonFilterBuilder.CreatePokemonFilter().AddName("Darkrai").OrderBy("hp").ThenBy("id", Ordering.Descending);
        var dictionary = new Dictionary<string, string>(filterBuilder);

        // assert
        Assert.That(dictionary, Is.EqualTo(dicObj));
    }

    [Test]
    public void PokemonFilter_OrderBy_TwoThenBy()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"name", "Darkrai"},
            {"orderby", "hp"},
            {"thenby", "id,supertype"},
        };

        // act
        var filterBuilder = PokemonFilterBuilder.CreatePokemonFilter().AddName("Darkrai").OrderBy("hp").ThenBy("id").ThenBy("supertype");
        var dictionary = new Dictionary<string, string>(filterBuilder);

        // assert
        Assert.That(dictionary, Is.EqualTo(dicObj));
    }

    [Test]
    public void TrainerFilter_Name()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"name", "Misty's Favor"}
        };

        // act
        var filterBuilder = TrainerFilterBuilder.CreateTrainerFilter().AddName("Misty's Favor");

        // assert
        Assert.That(filterBuilder, Is.EqualTo(dicObj));
    }


    [Test]
    public void TrainerFilter_Name_OrderBy()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"name", "Misty's Favor"},
            {"orderby", "number"}
        };

        // act
        var filterBuilder = TrainerFilterBuilder.CreateTrainerFilter().AddName("Misty's Favor").OrderBy("number");

        // assert
        Assert.That(filterBuilder, Is.EqualTo(dicObj));
    }

    [Test]
    public void TrainerFilter_Name_OrderByThenBy()
    {
        // assemble
        var dicObj = new Dictionary<string, string>
        {
            {"name", "Misty's Favor"},
            {"orderby", "number"},
            {"thenby", "artist"},
        };

        // act
        var filterBuilder = TrainerFilterBuilder.CreateTrainerFilter().AddName("Misty's Favor").OrderBy("number").ThenBy("artist");

        // assert
        Assert.That(filterBuilder, Is.EqualTo(dicObj));
    }
}