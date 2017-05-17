# Pokemon API SDK - C#

__NOTE:__ THIS PROJECT IS VERY MUCH STILL IN DEVELOPMENT AND NOT CURRENTLY MEANT TO BE USED IN AN APPLICATION

Included in this repository are two projects:

* PokemonTcgSdk
* PokemonTcgSdkConsole

_PokemonTcgSdk_ is a clas library which holds all of the code to get the data from the API and return C# classes.
_PokemonTcgSdkConsole_ is a console application to test the calls from the _PokemonTcgSdk_ project.

In the _PokemonTcgSdk_ project, there is a class called _QueryBuilder_ which contains all of the logic to get the actual cards. There is another class called _Card_ which is a wrapper around _QueryBuilder_ that is used similarly to the other SDK projects to get cards based on `id` and `type` and or `string` arguments.

In the _PokemonTcgSdkConsole_ project are examples on how the _Card_ class mentioned above are used.

## Examples

```
PokemonCard card = Card.Find<PokemonCard>("base4-4");
```
returns the JSON object for that card.

```
PokemonCardObject card = Card.Get<PokemonCardObject>("cards");
```
returns the JSON array of objects for the default call to the API.

```
Dictionary<string, string> args = new Dictionary<string, string>();
args.Add("supertype", "trainer");
args.Add("pageSize", "10");

TrainerCardObject card = Card.Get<TrainerCardObject>("cards", args);
```
returns the first 10 cards based on the `trainer` supertype.