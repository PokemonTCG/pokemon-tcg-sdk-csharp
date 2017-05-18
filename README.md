# Pokémon TCG SDK

This is the Pokémon TCG SDK C# implementation. It is a wrapper around the Pokémon TCG API of [pokemontcg.io](https://pokemontcg.io/).

## Installation

Coming soon to NuGet!

## Classes

```
Pokemon
PokemonCard
Trainer
TrainerCard
Set
SetData
TypeData
SuperType
SubType
```

## Helper Classes

In places where you would use these helper classes (examples below), strings can also be used if you prefer. These directly map to what's available on the [API](https://docs.pokemontcg.io/#cards).
```
ResourceTypes
CardQueryTypes
SetQueryTypes
```

## Properties Per Class

#### Pokemon, Set, Trainer

```
Card
Cards
```

#### PokemonCard, TrainerCard

```
Id
Name
NationalPokedexNumber
ImageUrl
ImageUrlHiRes
SubType
SuperType
Abilities
AncientTrait
Hp
Number
Artist
Rarity
Series
Set
SetCode
RetreatCost
Text
Types
Attacks
Weaknesses
Resistances
```

#### SetData

```
Code
Name
Series
TotalCards
StandardLegal
ExpandedLegal
ReleaseDate
```

#### TypeData, SuperTypes, SubTypes
```
Types
```

## Functions Available

#### Find a card by id

```
Pokemon card = Card.Find<Pokemon>(ResourceTypes.Cards, "base4-4");
```

#### Filter Cards via query parameters

```
Dictionary<string, string> args = new Dictionary<string, string>();
args.Add(CardQueryTypes.SuperType, "trainer");
args.Add(CardQueryTypes.PageSize, "1");

Trainer card = Card.Get<Trainer>(ResourceTypes.Cards, args);
```

#### Get all cards, but only a specific page of data
```
Dictionary<string, string> args = new Dictionary<string, string>();
args.Add(CardQueryTypes.Page, "5");
args.Add(CardQueryTypes.PageSize, "100");

Pokemon card = Card.Get<Pokemon>(ResourceTypes.Cards, args);
```

#### Find a set by code

```
Set set = Sets.Find<Set>(ResourceTypes.Sets, "base1");
```

#### Filter sets via query parameters

```
Dictionary<string, string> args = new Dictionary<string, string>();
args.Add(SetQueryTypes.Page, "true");

Set set = Card.Get<Set>(ResourceTypes.Sets, args);
```