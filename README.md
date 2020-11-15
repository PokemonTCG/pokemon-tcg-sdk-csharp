# Pokémon TCG SDK

This is the Pokémon TCG SDK C# implementation. It is a wrapper around the Pokémon TCG API of [pokemontcg.io](https://pokemontcg.io/).

### Installation

Install via NuGet
```PM> Install-Package PokemonTcgSdk -Version 1.0.0```

### Usage

#### Classes

The following classes are available in the PokemonTcgSdk namespace

```C#
Card
Energy
Pokemon
Sets
SubTypes
SuperTypes
Trainer
Types
```

The following classes are available in the PokemonTcgSdk.Models namespace

```C#
Ability
AncientTrait
Attack
BaseCard
EnergyCard
PokemonCard
SetData
SubType
SuperType
TrainerCard
TypeData
Weakness
```

##### Properties Per Class

###### Ability

```C#
string Name
string Text
string Type
```

###### AncientTrait

```C#
string Name
string Text
```

###### Attack

```C#
List<string> Cost
string Name
string Text
string Damage
int ConvertedEnergyCost
```

###### BaseCard

```C#
string Id
string Name
string ImageUrl
string ImageUrlHiRes
string SubType
string SuperType
string Number
string Artist
string Rarity
string Series
string Set
string SetCode
```

###### EnergyCard

Inherits from `BaseCard`

```C#
List<string> Text
```

###### PokemonCard

Inherits from `BaseCard`

```C#
int NationalPokedexNumber
string Hp
List<string> RetreatCost
Ability Ability
AncientTrait AncientTrait
List<string> Types
List<Attack> Attacks
List<Weakness> Weaknesses
List<Weakness> Resistances
```

###### SetData

```C#
string Code
string Name
string Series
int TotalCards
bool StandardLegal
bool ExpandedLegal
string ReleaseDate
```

###### SubType

```C#
List<string> Types
```

###### SuperType

```C#
List<string> Types
```

###### TrainerCard

Inherits from `BaseCard`

```C#
List<string> Text
```

###### TypeData

```C#
List<string> Types
```

###### Weakness

```C#
string Type
string Value
```

##### Methods Per Class

###### Card

```C#
// Get a card via a query string
T Get<T>(Dictionary<string, string> query)
// Async: Get a card via query string
Task<T> GetAsync<T>(Dictionary<string, string> query)

// Get a Pokemon card via a query string
Pokemon Get(Dictionary<string, string> query)
// Async: Get a Pokemon card via a query string
Task<Pokemon> GetAsync(Dictionary<string, string> query)

// Find a card by id
T Find<T>(string id)
// Async: Find a card by id
Task<T> FindAsync<T>(string id)

// Get all Pokemon cards (will take awhile)
List<PokemonCard> All(Dictionary<string, string> query)
// Async: Get all Pokemon cards (will take awhile)
Task<List<PokemonCard>> AllAsync(Dictionary<string, string> query)
```

###### Sets

```C#
// Find a set via a query string
List<SetData> Find(Dictionary<string, string> query)
// Async: Find a set via a query string
Task<List<SetData>> FindAsync(Dictionary<string, string> query)

// Get all sets
List<SetData> All(Dictionary<string, string> query)
// Async: Get all sets
Task<List<SetData>> AllAsync(Dictionary<string, string> query)
```

###### SubTypes

```C#
// Get all subtypes
List<string> All()
```

###### SuperTypes

```C#
// Get all supertypes
List<string> All()
// Async: Get all supertypes
Task<List<string>> AllAsync()
```

###### Types

```C#
// Get all types
List<string> All()
// Async: Get all types
Task<List<string>> AllAsync()
```

##### Examples

```C#
// Get a default list of Trainer cards
var cards = Card.Get<Trainer>();
cards.Cards;
// Async: Get a default list of Trainer cards
var cards = await Card.GetAsync<Trainer>();
cards.Cards;

// Get a default list of Pokemon cards
var cards = Card.Get<Pokemon>();
cards.Cards;
// Async: Get a default list of Pokemon cards
var cards = await Card.GetAsync<Pokemon>();
cards.Cards;

// Get a default list of Energy cards
var cards = Card.Get<Energy>();
cards.Cards;
// Async: Get a default list of Energy cards
var cards = await Card.GetAsync<Energy>();
cards.Cards;

// Get a list of cards via a query string
Dictionary<string, string> query = new Dictionary<string, string>()
{
    { "name", "Charizard" },
    { "set", "Base" }
};
var cards = Card.Get(query);
cards.Cards;
// Async: Get a list of cards via a query string
Dictionary<string, string> query = new Dictionary<string, string>()
{
    { "name", "Charizard" },
    { "set", "Base" }
};
var cards = await Card.GetAsync(query);
cards.Cards;

// Get a Pokemon card by id
var card = Card.Find<Pokemon>("base4-4");
card.Card;
// Async: Get a Pokemon card by id
var card = await Card.FindAsync<Pokemon>("base4-4");
card.Card;

// Get a Trainer card by id
var card = Card.Find<Trainer>("xy7-79");
card.Card;
// Async: Get a Trainer card by id
var card = await Card.FindAsync<Trainer>("xy7-79");
card.Card;

// Get all cards in a list
var cards = Card.All();
// Async: Get all cards in a list
var cards = await Card.AllAsync();

// Get a list of Sets via a query string
 var query = new Dictionary<string, string>()
{
    { "standardLegal", true.ToString() }
};
var sets = Sets.Find(query);
// Async: Get a list of Sets via a query string
 var query = new Dictionary<string, string>()
{
    { "standardLegal", true.ToString() }
};
var sets = await Sets.FindAsync(query);

// Get all Sets
var sets = Sets.All();
// Async: Get all Sets
var sets = await Sets.AllAsync();

// Get all super/sub/types
var supertypes = SuperTypes.All();
var subtypes = SubTypes.All();
var types = Types.All();
// Async: Get all super/sub/types
var supertypes = await SuperTypes.AllAsync();
var subtypes = await SubTypes.AllAsync();
var types = await Types.AllAsync();
```

## Contributing
 * Fork it (click the Fork button at the top of the page)
 * Create your feature branch (git checkout -b my-new-feature)
 * Commit your changes (git commit -am 'Add some feature')
 * Push to the branch (git push origin my-new-feature)
 * Create a new Pull Request
