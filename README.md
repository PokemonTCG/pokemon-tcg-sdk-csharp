
# Pokémon TCG SDK C#
A .Net wrapper for the Pokemon API at [pokemontcg.io](https://pokemontcg.io).

Targets .Net Standard 2.0+.

[![Nuget](https://img.shields.io/nuget/v/PokemonTcgSdk?style=flat-square)](https://www.nuget.org/packages/PokemonTcgSdk)

# Use
As of v2 of the api an api key is needed to get the full benefit of it. This can be aquired at [pokemontcg.io](https://pokemontcg.io), without using a key rate limits are a lot lower.
```cs
// instantiate client
PokemonApiClient pokeClient = new PokemonApiClient();
```
Internally, `PokemonApiClient`   uses an instance of the `HttpClient` class. As such, instances of `PokemonApiClient` are [meant to be instantiated once and re-used throughout the life of an application.](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netcore-3.1#remarks)
```c# 
  // instantiate client
PokemonApiClient pokeClient = new PokemonApiClient();

  // instantiate client with your api key
PokemonApiClient pokeClient = new PokemonApiClient("YOUR-API-KEY");
```

There are additional `PokemonApiClient` constructors that support your own httpclients as well as `HttpMessageHandler`. This is especially useful when used in projects where [IHttpClientFactory is used to create and configure HttpClient instances with different policies](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0).
```c#
// your httpclient (factory, named clients, typed clients, generated clients)
var client = _httpClientFactory.CreateClient();

// Add your api key as a header
client.DefaultRequestHeaders.Add("X-Api-Key", "YOUR-API-KEY");

// instantiate client
PokemonApiClient pokeClient = new PokemonApiClient(client);
```

## Method Definitions
```c#
// gets all cards regardless of type
var card = await pokeClient.GetApiResourceAsync<Card>();

// with pagination. take on the api is limited to a max of 250
var card = await pokeClient.GetApiResourceAsync<Card>(take: 10, skip: 2);

// Pokemon Cards
var card = await pokeClient.GetApiResourceAsync<PokemonCard>();
var card = await pokeClient.GetApiResourceAsync<PokemonCard>(take: 10, skip: 2);

// Trainer Cards
var card = await pokeClient.GetApiResourceAsync<TrainerCard>();
var card = await pokeClient.GetApiResourceAsync<TrainerCard>(take: 10, skip: 2);

// Energy Cards
var card = await pokeClient.GetApiResourceAsync<EnergyCard>();
var card = await pokeClient.GetApiResourceAsync<EnergyCard>(take: 10, skip: 2);

//Sets
var card = await pokeClient.GetApiResourceAsync<Set>();
var card = await pokeClient.GetApiResourceAsync<Set>(take: 10, skip: 2);
```
## Filter Definitions
Each type (PokemonCard, TrainerCard, EnergyCard, Set) have some helpful fluent like filter extensions that cover off a lot of the usual filter needs. These can be stacked also.
```c#
PokemonFilterBuilder.CreatePokemonFilter()
EnergyFilterBuilder.CreateEnergyFilter(
TrainerFilterBuilder.CreateTrainerFilter()
SetFilterBuilder.CreateSetFilter()
```
e.g
```c#
var filter = PokemonFilterBuilder.CreatePokemonFilter().AddName("Darkrai");
var filter = PokemonFilterBuilder.CreatePokemonFilter()
    .AddName("Darkrai")
    .AddName("Pikachu")
    .AddSetName("Base");
```
Most of the filter extensions are prefixed with Add 
```c#
// Pokemon
AddId()
AddName()
AddSubTypes()
AddHpRange()
AddTypes()
AddEvolvesFrom()
AddEvolvesTo()
AddAttackCostRange()
AddSetName()
AddSetSeries()
AddSetId()
AddRarity()

// Sets
AddId()
AddName()
AddSeries()
AddPtcgoCode()

// Trainer
AddId()
AddName()
AddSetName()
AddSetSeries()

// Energy
AddId()
AddName()
AddSubTypes()
AddSetName()
AddSetSeries()
```
There is also a custom extension to bring only Pokemon cards that have an ancient trait
```c#
var filter = PokemonFilterBuilder.CreatePokemonFilter().HasAncientTrait();
```
If the filter extensions don't cover off everything you can build up your own
```c#
var filter = PokemonFilterBuilder.CreatePokemonFilter()
            .AddName("Darkrai")
            .AddName("Pikachu")
            .AddSubTypes("Stage 1")
            .AddHpRange("60", "120", false)
            .AddRarity("Common")
            .AddAttackCostRange("2", "4", false)
            .AddEvolvesFrom("Pikachu");
// custom addition
filter.Add("legalities.standard", "legal");
```
Please see offical documentation for more advance filters until these are added in as extension.

For example, if you don't want to use any extension methods you can create your own filter from scratch. 
Be aware that the key needs to match the json fields in the api return, as well as casing. 
Also for multiple matches (so OR filter) this is done by seperating with a comma, no spaces as the example of "name" shows below.
```c#
 var filter = new Dictionary<string, string>
 {
     {"name", "Darkrai,Pikachu"},
     {"subtypes", "Stage 1"},
     {"hp", "{60 TO 120}"},
     {"rarity", "Common"},
     {"attacks.convertedEnergyCost", "{2 TO 4}"},
     {"evolvesfrom", "Pikachu"}
 };
```
#### Ordering Filters
`PokemonFilterBuilder`, `EnergyFilterBuilder` and `TrainerFilterBuilder` all support fluent like OrderBy/ThenBy. Along with the ability to order ASC or DESC (ASC is default). You can only have one OrderBy, but multiple ThenBy's.

Remember that OrderBy/ThenBy's are case API sensitive (camel case)

```c#
var filter = PokemonFilterBuilder.CreatePokemonFilter()
            .AddName("Darkrai")
            .OrderBy("hp");
```
Or
```c#
var filter = PokemonFilterBuilder.CreatePokemonFilter()
            .AddName("Darkrai")
            .OrderBy(nameof(PokemonCard.Hp));
```
Descending:
```c#
var filter = PokemonFilterBuilder.CreatePokemonFilter()
            .AddName("Darkrai")
            .OrderBy("hp", Ordering.Descending);
```
ThenBy:
```c#
var filter = PokemonFilterBuilder.CreatePokemonFilter()
            .AddName("Darkrai")
            .OrderBy("hp")
            .ThenBy("id");
```
```c#
var filter = PokemonFilterBuilder.CreatePokemonFilter()
            .AddName("Darkrai")
            .OrderBy("hp")
            .ThenBy("id", Ordering.Descending);
```

You can also build up the OrderBy filters without using the fluent like extensions:

#### ASC
```c#
 var filter = new Dictionary<string, string>
 {
     {"name", "Darkrai,Pikachu"},
     {"subtypes", "Stage 1"},
     {"hp", "{60 TO 120}"},
     {"rarity", "Common"},
     {"attacks.convertedEnergyCost", "{2 TO 4}"},
     {"evolvesfrom", "Pikachu"},
     {"orderby", "hp"},
 };
```
```c#
 var filter = new Dictionary<string, string>
 {
     {"name", "Darkrai,Pikachu"},
     {"subtypes", "Stage 1"},
     {"hp", "{60 TO 120}"},
     {"rarity", "Common"},
     {"attacks.convertedEnergyCost", "{2 TO 4}"},
     {"evolvesfrom", "Pikachu"},
     {"orderby", "hp"},
     {"thenby", "id"},
 };
```
#### DESC
```c#
 var filter = new Dictionary<string, string>
 {
     {"name", "Darkrai,Pikachu"},
     {"subtypes", "Stage 1"},
     {"hp", "{60 TO 120}"},
     {"rarity", "Common"},
     {"attacks.convertedEnergyCost", "{2 TO 4}"},
     {"evolvesfrom", "Pikachu"},
     {"orderby", "-hp"},
 };
```
```c#
 var filter = new Dictionary<string, string>
 {
     {"name", "Darkrai,Pikachu"},
     {"subtypes", "Stage 1"},
     {"hp", "{60 TO 120}"},
     {"rarity", "Common"},
     {"attacks.convertedEnergyCost", "{2 TO 4}"},
     {"evolvesfrom", "Pikachu"},
     {"orderby", "hp"},
     {"thenby", "-id"},
 };
```

### Using Filters
Once you have built up the filter you can pass it into your call method. Pagination is still supported
```c#
var filter = PokemonFilterBuilder.CreatePokemonFilter().AddName("Darkrai");
var cards = await pokeClient.GetApiResourceAsync<PokemonCard>(filter);
var cards = await pokeClient.GetApiResourceAsync<PokemonCard>(10, 2, filter);
```
## String Method Definitions
As these lists are small and of type ```List<string>``` these will return all.
##### SubType
```c#
var types = await pokeClient.GetStringResourceAsync<SubTypes>();
```
##### SuperType
```c#
var types = await pokeClient.GetStringResourceAsync<SuperTypes>();
```
##### ElementTypes
```c#
var types = await pokeClient.GetStringResourceAsync<ElementTypes>();
```
##### Rarities
```c#
var rarities = await pokeClient.GetStringResourceAsync<Rarities>();
```
## Caching
Every resource response is automatically cached in memory, making all subsequent requests for the same resource (url matching) pull cached data. Example:
```c#
// this will fetch the data from the API  
 var filter = PokemonFilterBuilder.CreatePokemonFilter()
   .AddName("Darkrai");
var darkrai = await pokeClient.GetApiResourceAsync<Pokemon>(filter);

// another call to the same resource will fetch from the cache
 var filterBuilder = PokemonFilterBuilder.CreatePokemonFilter()
     .AddName("Darkrai");
 var darkrai = await pokeClient.GetApiResourceAsync<Pokemon>(filter);    
```
This can be confirmed by:
```c#
var fromCache = darkrai.FromCache;
```

To clear the cache of data:
```c#
// clear all caches for all resources
pokeClient.ClearCache();
```
Additional overloads are provided to allow for clearing the individual caches for resources, as well as by type of cache.

## Class Definitions
```C#
Card
EnergyCard
PokemonCard
TrainerCard
Sets
SubTypes
SuperTypes
Types
Rarities
``` 
##### Card

```C#
    public string Id { get; set; }
    public string Name { get; set; }
    public string Supertype { get; set; }
    public List<string> Subtypes { get; set; }
    public string Level { get; set; }
    public int Hp { get; set; }
    public List<string> Types { get; set; }
    public string EvolvesFrom { get; set; }
    public AncientTrait AncientTrait { get; set; }
    public List<Ability> Abilities { get; set; }
    public List<Attack> Attacks { get; set; }
    public List<Resistance> Weaknesses { get; set; }
    public List<Resistance> Resistances { get; set; }
    public List<string> RetreatCost { get; set; }
    public int ConvertedRetreatCost { get; set; }
    public Set Set { get; set; }
    public string Number { get; set; }
    public string Artist { get; set; }
    public string Rarity { get; set; }
    public List<int> NationalPokedexNumbers { get; set; }
    public Legalities Legalities { get; set; }
    public CardImage Images { get; set; }
    public TcgPlayer Tcgplayer { get; set; }
    public CardMarket Cardmarket { get; set; }
    public List<string> EvolvesTo { get; set; }
    public string FlavorText { get; set; }
    public List<string> Rules { get; set; }
    public string RegulationMark { get; set; }
``` 

##### PokemonCard
```c#
    public string Id { get; set; }
    public string Name { get; set; }
    public string Supertype { get; set; }
    public List<string> Subtypes { get; set; }
    public int Level { get; set; }
    public int Hp { get; set; }
    public List<string> Types { get; set; }
    public string EvolvesFrom { get; set; }
    public AncientTrait AncientTrait { get; set; }
    public List<Ability> Abilities { get; set; }
    public List<Attack> Attacks { get; set; }
    public List<Resistance> Weaknesses { get; set; }
    public List<Resistance> Resistances { get; set; }
    public List<string> RetreatCost { get; set; }
    public int ConvertedRetreatCost { get; set; }
    public Set Set { get; set; }
    public string Number { get; set; }
    public string Artist { get; set; }
    public string Rarity { get; set; }
    public List<int> NationalPokedexNumbers { get; set; }
    public Legalities Legalities { get; set; }
    public CardImage Images { get; set; }
    public TcgPlayer Tcgplayer { get; set; }
    public CardMarket Cardmarket { get; set; }
    public List<string> EvolvesTo { get; set; }
    public string FlavorText { get; set; }
    public List<string> Rules { get; set; }
    public string RegulationMark { get; set; }
```
##### TrainerCard
````c#
    public string Id { get; set; }
    public string Name { get; set; }
    public string Supertype { get; set; }
    public List<string> Rules { get; set; }
    public Set Set { get; set; }
    public string Number { get; set; }
    public string Artist { get; set; }
    public string Rarity { get; set; }
    public Legalities Legalities { get; set; }
    public CardImage Images { get; set; }
    public TcgPlayer Tcgplayer { get; set; }
    public CardMarket Cardmarket { get; set; }
    public List<string> Subtypes { get; set; }
    public List<Attack> Attacks { get; set; }
    public string RegulationMark { get; set; }
    public int Hp { get; set; }
    public List<Ability> Abilities { get; set; }
````
##### EnergyCard
```c#
string Id 
string Name
string Supertype
List<string> Subtypes
List<string> Rules
Set Set
string Number
string Artist
string Rarity
Legalities Legalities
CardImage Images
TcgPlayer Tcgplayer
CardMarket Cardmarket
```    
###### Ability
```c#
string  Name
string  Text
string  Type
```
###### Ancient Trait
```c#
string  Name
string  Text
```
###### Attack
```c#
List<string> Cost
string  Name
string  Text
string  Damage
int  ConvertedEnergyCost
```
###### CardImage
```c#
Uri Small
Uri Large
```
###### Resistance
```c#
string  Type
string  Value
```
###### TcgPlayer
```c#
Uri Url
string UpdatedAt
TcgPlayerPrices Prices 
```
###### TcgPlayerPrices
```c#
Prices Holofoil
Prices ReverseHolofoil
Prices Normal
Prices The1StEditionHolofoil
Prices UnlimitedHolofoil
Prices The1StEdition
Prices Unlimited
```
###### Prices
```c#
double Low
double Mid
double High
double Market
double DirectLow
```
###### CardMarket
```c#
Uri Url
string UpdatedAt
CardMarketPrices Prices 
```
###### CardMarketPrices
```c#
decimal? AverageSellPrice 
decimal? LowPrice 
decimal? TrendPrice 
decimal? ReverseHoloSell 
decimal? ReverseHoloLow 
decimal? ReverseHoloTrend 
decimal? LowPriceExPlus 
decimal? AverageDay 
decimal? AverageWeek 
decimal? AverageMonth 
decimal? AverageDayReverseHolo 
decimal? AverageWeekReverseHolo 
decimal? AverageMonthReverseHolo
```
###### SetData
```c#
string Id
string Name
string Series
long PrintedTotal
long Total
Legalities Legalities
string PtcgoCode
string ReleaseDate
string UpdatedAt
Images Images
```

## Contributing

* -   Open an issue
    -   Describe what the SDK is missing and what changes you'd like to see implemented
    -   **Ask clarifying questions**
* Fork it (click the Fork button at the top of the page)
* Create your feature branch (git checkout -b my-new-feature)
* Commit your changes (git commit -am 'Add some feature')
* Push to the branch (git push origin my-new-feature)
* Create a new Pull Request to ```develop```
