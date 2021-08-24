<a name='assembly'></a>
# PokemonTcgSdk-v2-alpha

## Contents

- [Ability](#T-PokemonTcgSdkV2-Api-Cards-Ability 'PokemonTcgSdkV2.Api.Cards.Ability')
  - [Name](#P-PokemonTcgSdkV2-Api-Cards-Ability-Name 'PokemonTcgSdkV2.Api.Cards.Ability.Name')
  - [Text](#P-PokemonTcgSdkV2-Api-Cards-Ability-Text 'PokemonTcgSdkV2.Api.Cards.Ability.Text')
  - [Type](#P-PokemonTcgSdkV2-Api-Cards-Ability-Type 'PokemonTcgSdkV2.Api.Cards.Ability.Type')
- [AncientTrait](#T-PokemonTcgSdkV2-Api-Cards-AncientTrait 'PokemonTcgSdkV2.Api.Cards.AncientTrait')
  - [Name](#P-PokemonTcgSdkV2-Api-Cards-AncientTrait-Name 'PokemonTcgSdkV2.Api.Cards.AncientTrait.Name')
  - [Text](#P-PokemonTcgSdkV2-Api-Cards-AncientTrait-Text 'PokemonTcgSdkV2.Api.Cards.AncientTrait.Text')
- [Attack](#T-PokemonTcgSdkV2-Api-Cards-Attack 'PokemonTcgSdkV2.Api.Cards.Attack')
  - [ConvertedEnergyCost](#P-PokemonTcgSdkV2-Api-Cards-Attack-ConvertedEnergyCost 'PokemonTcgSdkV2.Api.Cards.Attack.ConvertedEnergyCost')
  - [Costs](#P-PokemonTcgSdkV2-Api-Cards-Attack-Costs 'PokemonTcgSdkV2.Api.Cards.Attack.Costs')
  - [Damage](#P-PokemonTcgSdkV2-Api-Cards-Attack-Damage 'PokemonTcgSdkV2.Api.Cards.Attack.Damage')
  - [Name](#P-PokemonTcgSdkV2-Api-Cards-Attack-Name 'PokemonTcgSdkV2.Api.Cards.Attack.Name')
  - [Text](#P-PokemonTcgSdkV2-Api-Cards-Attack-Text 'PokemonTcgSdkV2.Api.Cards.Attack.Text')
- [Card](#T-PokemonTcgSdkV2-Api-Cards-Card 'PokemonTcgSdkV2.Api.Cards.Card')
  - [Abilities](#P-PokemonTcgSdkV2-Api-Cards-Card-Abilities 'PokemonTcgSdkV2.Api.Cards.Card.Abilities')
  - [AncientTrait](#P-PokemonTcgSdkV2-Api-Cards-Card-AncientTrait 'PokemonTcgSdkV2.Api.Cards.Card.AncientTrait')
  - [Artist](#P-PokemonTcgSdkV2-Api-Cards-Card-Artist 'PokemonTcgSdkV2.Api.Cards.Card.Artist')
  - [Attacks](#P-PokemonTcgSdkV2-Api-Cards-Card-Attacks 'PokemonTcgSdkV2.Api.Cards.Card.Attacks')
  - [Cardmarket](#P-PokemonTcgSdkV2-Api-Cards-Card-Cardmarket 'PokemonTcgSdkV2.Api.Cards.Card.Cardmarket')
  - [ConvertedRetreatCost](#P-PokemonTcgSdkV2-Api-Cards-Card-ConvertedRetreatCost 'PokemonTcgSdkV2.Api.Cards.Card.ConvertedRetreatCost')
  - [EvolvesFrom](#P-PokemonTcgSdkV2-Api-Cards-Card-EvolvesFrom 'PokemonTcgSdkV2.Api.Cards.Card.EvolvesFrom')
  - [EvolvesTo](#P-PokemonTcgSdkV2-Api-Cards-Card-EvolvesTo 'PokemonTcgSdkV2.Api.Cards.Card.EvolvesTo')
  - [FlavorText](#P-PokemonTcgSdkV2-Api-Cards-Card-FlavorText 'PokemonTcgSdkV2.Api.Cards.Card.FlavorText')
  - [Hitpoints](#P-PokemonTcgSdkV2-Api-Cards-Card-Hitpoints 'PokemonTcgSdkV2.Api.Cards.Card.Hitpoints')
  - [Images](#P-PokemonTcgSdkV2-Api-Cards-Card-Images 'PokemonTcgSdkV2.Api.Cards.Card.Images')
  - [Legalities](#P-PokemonTcgSdkV2-Api-Cards-Card-Legalities 'PokemonTcgSdkV2.Api.Cards.Card.Legalities')
  - [Level](#P-PokemonTcgSdkV2-Api-Cards-Card-Level 'PokemonTcgSdkV2.Api.Cards.Card.Level')
  - [Name](#P-PokemonTcgSdkV2-Api-Cards-Card-Name 'PokemonTcgSdkV2.Api.Cards.Card.Name')
  - [NationalPokedexNumbers](#P-PokemonTcgSdkV2-Api-Cards-Card-NationalPokedexNumbers 'PokemonTcgSdkV2.Api.Cards.Card.NationalPokedexNumbers')
  - [Number](#P-PokemonTcgSdkV2-Api-Cards-Card-Number 'PokemonTcgSdkV2.Api.Cards.Card.Number')
  - [Rarity](#P-PokemonTcgSdkV2-Api-Cards-Card-Rarity 'PokemonTcgSdkV2.Api.Cards.Card.Rarity')
  - [Resistances](#P-PokemonTcgSdkV2-Api-Cards-Card-Resistances 'PokemonTcgSdkV2.Api.Cards.Card.Resistances')
  - [RetreatCosts](#P-PokemonTcgSdkV2-Api-Cards-Card-RetreatCosts 'PokemonTcgSdkV2.Api.Cards.Card.RetreatCosts')
  - [Rules](#P-PokemonTcgSdkV2-Api-Cards-Card-Rules 'PokemonTcgSdkV2.Api.Cards.Card.Rules')
  - [Set](#P-PokemonTcgSdkV2-Api-Cards-Card-Set 'PokemonTcgSdkV2.Api.Cards.Card.Set')
  - [Subtypes](#P-PokemonTcgSdkV2-Api-Cards-Card-Subtypes 'PokemonTcgSdkV2.Api.Cards.Card.Subtypes')
  - [Supertype](#P-PokemonTcgSdkV2-Api-Cards-Card-Supertype 'PokemonTcgSdkV2.Api.Cards.Card.Supertype')
  - [TcgPlayer](#P-PokemonTcgSdkV2-Api-Cards-Card-TcgPlayer 'PokemonTcgSdkV2.Api.Cards.Card.TcgPlayer')
  - [Types](#P-PokemonTcgSdkV2-Api-Cards-Card-Types 'PokemonTcgSdkV2.Api.Cards.Card.Types')
  - [Weakness](#P-PokemonTcgSdkV2-Api-Cards-Card-Weakness 'PokemonTcgSdkV2.Api.Cards.Card.Weakness')
- [CardImages](#T-PokemonTcgSdkV2-Api-Cards-CardImages 'PokemonTcgSdkV2.Api.Cards.CardImages')
  - [LargeImageUrl](#P-PokemonTcgSdkV2-Api-Cards-CardImages-LargeImageUrl 'PokemonTcgSdkV2.Api.Cards.CardImages.LargeImageUrl')
  - [SmallImageUrl](#P-PokemonTcgSdkV2-Api-Cards-CardImages-SmallImageUrl 'PokemonTcgSdkV2.Api.Cards.CardImages.SmallImageUrl')
- [CardmarketEntry](#T-PokemonTcgSdkV2-Api-Cardmarket-CardmarketEntry 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketEntry')
  - [Prices](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketEntry-Prices 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketEntry.Prices')
  - [UpdatedAt](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketEntry-UpdatedAt 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketEntry.UpdatedAt')
  - [Url](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketEntry-Url 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketEntry.Url')
- [CardmarketPrice](#T-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice')
  - [AverageDay](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageDay 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.AverageDay')
  - [AverageDayReverseHolo](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageDayReverseHolo 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.AverageDayReverseHolo')
  - [AverageMonth](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageMonth 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.AverageMonth')
  - [AverageMonthReverseHolo](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageMonthReverseHolo 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.AverageMonthReverseHolo')
  - [AverageSellPrice](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageSellPrice 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.AverageSellPrice')
  - [AverageWeek](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageWeek 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.AverageWeek')
  - [AverageWeekReverseHolo](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageWeekReverseHolo 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.AverageWeekReverseHolo')
  - [GermanProLow](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-GermanProLow 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.GermanProLow')
  - [LowPrice](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-LowPrice 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.LowPrice')
  - [LowPriceExPlus](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-LowPriceExPlus 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.LowPriceExPlus')
  - [ReverseHoloLow](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-ReverseHoloLow 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.ReverseHoloLow')
  - [ReverseHoloSell](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-ReverseHoloSell 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.ReverseHoloSell')
  - [ReverseHoloTrend](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-ReverseHoloTrend 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.ReverseHoloTrend')
  - [SuggestedPrice](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-SuggestedPrice 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.SuggestedPrice')
  - [TrendPrice](#P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-TrendPrice 'PokemonTcgSdkV2.Api.Cardmarket.CardmarketPrice.TrendPrice')
- [FetchableApiObject](#T-PokemonTcgSdkV2-Api-FetchableApiObject 'PokemonTcgSdkV2.Api.FetchableApiObject')
- [IApiObjectWithId](#T-PokemonTcgSdkV2-Api-IApiObjectWithId 'PokemonTcgSdkV2.Api.IApiObjectWithId')
  - [Id](#P-PokemonTcgSdkV2-Api-IApiObjectWithId-Id 'PokemonTcgSdkV2.Api.IApiObjectWithId.Id')
- [Legalities](#T-PokemonTcgSdkV2-Api-Cards-Legalities 'PokemonTcgSdkV2.Api.Cards.Legalities')
  - [Expanded](#P-PokemonTcgSdkV2-Api-Cards-Legalities-Expanded 'PokemonTcgSdkV2.Api.Cards.Legalities.Expanded')
  - [Standard](#P-PokemonTcgSdkV2-Api-Cards-Legalities-Standard 'PokemonTcgSdkV2.Api.Cards.Legalities.Standard')
  - [Unlimited](#P-PokemonTcgSdkV2-Api-Cards-Legalities-Unlimited 'PokemonTcgSdkV2.Api.Cards.Legalities.Unlimited')
- [Set](#T-PokemonTcgSdkV2-Api-Sets-Set 'PokemonTcgSdkV2.Api.Sets.Set')
  - [Images](#P-PokemonTcgSdkV2-Api-Sets-Set-Images 'PokemonTcgSdkV2.Api.Sets.Set.Images')
  - [Legalities](#P-PokemonTcgSdkV2-Api-Sets-Set-Legalities 'PokemonTcgSdkV2.Api.Sets.Set.Legalities')
  - [Name](#P-PokemonTcgSdkV2-Api-Sets-Set-Name 'PokemonTcgSdkV2.Api.Sets.Set.Name')
  - [PrintedTotal](#P-PokemonTcgSdkV2-Api-Sets-Set-PrintedTotal 'PokemonTcgSdkV2.Api.Sets.Set.PrintedTotal')
  - [PtcgoCode](#P-PokemonTcgSdkV2-Api-Sets-Set-PtcgoCode 'PokemonTcgSdkV2.Api.Sets.Set.PtcgoCode')
  - [ReleaseDate](#P-PokemonTcgSdkV2-Api-Sets-Set-ReleaseDate 'PokemonTcgSdkV2.Api.Sets.Set.ReleaseDate')
  - [Series](#P-PokemonTcgSdkV2-Api-Sets-Set-Series 'PokemonTcgSdkV2.Api.Sets.Set.Series')
  - [Total](#P-PokemonTcgSdkV2-Api-Sets-Set-Total 'PokemonTcgSdkV2.Api.Sets.Set.Total')
  - [UpdatedAt](#P-PokemonTcgSdkV2-Api-Sets-Set-UpdatedAt 'PokemonTcgSdkV2.Api.Sets.Set.UpdatedAt')
- [SetImages](#T-PokemonTcgSdkV2-Api-Sets-SetImages 'PokemonTcgSdkV2.Api.Sets.SetImages')
  - [LogoImageUrl](#P-PokemonTcgSdkV2-Api-Sets-SetImages-LogoImageUrl 'PokemonTcgSdkV2.Api.Sets.SetImages.LogoImageUrl')
  - [SymbolImageUrl](#P-PokemonTcgSdkV2-Api-Sets-SetImages-SymbolImageUrl 'PokemonTcgSdkV2.Api.Sets.SetImages.SymbolImageUrl')
- [TcgPlayerEntry](#T-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerEntry 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerEntry')
  - [Prices](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerEntry-Prices 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerEntry.Prices')
  - [UpdatedAt](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerEntry-UpdatedAt 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerEntry.UpdatedAt')
  - [Url](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerEntry-Url 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerEntry.Url')
- [TcgPlayerPrice](#T-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPrice 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerPrice')
  - [DirectLow](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPrice-DirectLow 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerPrice.DirectLow')
  - [High](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPrice-High 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerPrice.High')
  - [Low](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPrice-Low 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerPrice.Low')
  - [Market](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPrice-Market 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerPrice.Market')
  - [Mid](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPrice-Mid 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerPrice.Mid')
- [TcgPlayerPriceSet](#T-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPriceSet 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerPriceSet')
  - [FirstEditionHolofoil](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPriceSet-FirstEditionHolofoil 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerPriceSet.FirstEditionHolofoil')
  - [FirstEditionNormal](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPriceSet-FirstEditionNormal 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerPriceSet.FirstEditionNormal')
  - [HoloFoil](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPriceSet-HoloFoil 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerPriceSet.HoloFoil')
  - [Normal](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPriceSet-Normal 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerPriceSet.Normal')
  - [ReverseHolofoil](#P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPriceSet-ReverseHolofoil 'PokemonTcgSdkV2.Api.TcgPlayer.TcgPlayerPriceSet.ReverseHolofoil')
- [WeaknessOrResistance](#T-PokemonTcgSdkV2-Api-Cards-WeaknessOrResistance 'PokemonTcgSdkV2.Api.Cards.WeaknessOrResistance')
  - [Type](#P-PokemonTcgSdkV2-Api-Cards-WeaknessOrResistance-Type 'PokemonTcgSdkV2.Api.Cards.WeaknessOrResistance.Type')
  - [Value](#P-PokemonTcgSdkV2-Api-Cards-WeaknessOrResistance-Value 'PokemonTcgSdkV2.Api.Cards.WeaknessOrResistance.Value')

<a name='T-PokemonTcgSdkV2-Api-Cards-Ability'></a>
## Ability `type`

##### Namespace

PokemonTcgSdkV2.Api.Cards

##### Summary

One or more abilities for a given card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Ability-Name'></a>
### Name `property`

##### Summary

The name of the ability.

<a name='P-PokemonTcgSdkV2-Api-Cards-Ability-Text'></a>
### Text `property`

##### Summary

The text value of the ability.

<a name='P-PokemonTcgSdkV2-Api-Cards-Ability-Type'></a>
### Type `property`

##### Summary

The type of the ability, such as Ability or Pokémon-Power.

<a name='T-PokemonTcgSdkV2-Api-Cards-AncientTrait'></a>
## AncientTrait `type`

##### Namespace

PokemonTcgSdkV2.Api.Cards

##### Summary

The ancient trait for a given card.

<a name='P-PokemonTcgSdkV2-Api-Cards-AncientTrait-Name'></a>
### Name `property`

##### Summary

The name of the ancient trait.

<a name='P-PokemonTcgSdkV2-Api-Cards-AncientTrait-Text'></a>
### Text `property`

##### Summary

The text value of the ancient trait.

<a name='T-PokemonTcgSdkV2-Api-Cards-Attack'></a>
## Attack `type`

##### Namespace

PokemonTcgSdkV2.Api.Cards

##### Summary

One or more attacks for a given card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Attack-ConvertedEnergyCost'></a>
### ConvertedEnergyCost `property`

##### Summary

The total cost of the attack. For example, if it costs 2 fire energy, the converted energy cost is simply 2.

<a name='P-PokemonTcgSdkV2-Api-Cards-Attack-Costs'></a>
### Costs `property`

##### Summary

The cost of the attack represented by a list of energy types.

<a name='P-PokemonTcgSdkV2-Api-Cards-Attack-Damage'></a>
### Damage `property`

##### Summary

The damage amount of the attack.

<a name='P-PokemonTcgSdkV2-Api-Cards-Attack-Name'></a>
### Name `property`

##### Summary

The name of the attack.

<a name='P-PokemonTcgSdkV2-Api-Cards-Attack-Text'></a>
### Text `property`

##### Summary

The text or description associated with the attack.

<a name='T-PokemonTcgSdkV2-Api-Cards-Card'></a>
## Card `type`

##### Namespace

PokemonTcgSdkV2.Api.Cards

##### Summary

Represents a single Pokémon card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Abilities'></a>
### Abilities `property`

##### Summary

One or more abilities for a given card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-AncientTrait'></a>
### AncientTrait `property`

##### Summary

The ancient trait for a given card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Artist'></a>
### Artist `property`

##### Summary

The artist of the card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Attacks'></a>
### Attacks `property`

##### Summary

One or more attacks for a given card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Cardmarket'></a>
### Cardmarket `property`

##### Summary

The https://www.cardmarket.com/ information for a given card.

##### Remarks

All prices are in Euros.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-ConvertedRetreatCost'></a>
### ConvertedRetreatCost `property`

##### Summary

The converted retreat cost for a card is the count of energy types found within the retreatCost field. For example,
    ["Fire", "Water"] has a converted retreat cost of 2.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-EvolvesFrom'></a>
### EvolvesFrom `property`

##### Summary

Which Pokémon this card evolves from.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-EvolvesTo'></a>
### EvolvesTo `property`

##### Summary

Which Pokémon this card evolves to.

##### Remarks

Can be multiple, for example, Eeve, which has multiple evolutions.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-FlavorText'></a>
### FlavorText `property`

##### Summary

The flavor text of the card. This is the text that can be found on some Pokémon cards that is usually italicized
    near the bottom of the card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Hitpoints'></a>
### Hitpoints `property`

##### Summary

The hit points of the card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Images'></a>
### Images `property`

##### Summary

The images for a card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Legalities'></a>
### Legalities `property`

##### Summary

The legalities for a given card.

##### Remarks

A legality will not be present in the [Legalities](#P-PokemonTcgSdkV2-Api-Cards-Card-Legalities 'PokemonTcgSdkV2.Api.Cards.Card.Legalities') if it is not legal. If it is legal or banned, it
    will be present.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Level'></a>
### Level `property`

##### Summary

The level of the card. This only pertains to cards from older sets and those of supertype Pokémon.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Name'></a>
### Name `property`

##### Summary

The name of the card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-NationalPokedexNumbers'></a>
### NationalPokedexNumbers `property`

##### Summary

The national pokedex numbers associated with any Pokémon featured on a given card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Number'></a>
### Number `property`

##### Summary

The number of the card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Rarity'></a>
### Rarity `property`

##### Summary

The rarity of the card, such as "Common" or "Rare Rainbow".

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Resistances'></a>
### Resistances `property`

##### Summary

One or more resistances for a given card.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-RetreatCosts'></a>
### RetreatCosts `property`

##### Summary

A list of costs it takes to retreat and return the card to your bench. Each cost is an energy type, such as Water
    or Fire.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Rules'></a>
### Rules `property`

##### Summary

Any rules associated with the card. For example, VMAX rules, Mega rules, or various trainer rules.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Set'></a>
### Set `property`

##### Summary

The set details embedded into the card.

##### Remarks

See the [Set](#P-PokemonTcgSdkV2-Api-Cards-Card-Set 'PokemonTcgSdkV2.Api.Cards.Card.Set') object for more details.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Subtypes'></a>
### Subtypes `property`

##### Summary

A list of subtypes, such as Basic, EX, Mega, Rapid Strike, etc.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Supertype'></a>
### Supertype `property`

##### Summary

The supertype of the card, such as Pokémon, Energy, or Trainer.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-TcgPlayer'></a>
### TcgPlayer `property`

##### Summary

The https://www.tcgplayer.com information for a given card.

##### Remarks

All prices are in US Dollars.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Types'></a>
### Types `property`

##### Summary

The energy types for a card, such as Fire, Water, Grass, etc.

<a name='P-PokemonTcgSdkV2-Api-Cards-Card-Weakness'></a>
### Weakness `property`

##### Summary

One or more weaknesses for a given card.

<a name='T-PokemonTcgSdkV2-Api-Cards-CardImages'></a>
## CardImages `type`

##### Namespace

PokemonTcgSdkV2.Api.Cards

<a name='P-PokemonTcgSdkV2-Api-Cards-CardImages-LargeImageUrl'></a>
### LargeImageUrl `property`

##### Summary

A larger, higher-res image for a card.

##### Remarks

This is a URL.

<a name='P-PokemonTcgSdkV2-Api-Cards-CardImages-SmallImageUrl'></a>
### SmallImageUrl `property`

##### Summary

A smaller, lower-res image for a card.

##### Remarks

This is a URL.

<a name='T-PokemonTcgSdkV2-Api-Cardmarket-CardmarketEntry'></a>
## CardmarketEntry `type`

##### Namespace

PokemonTcgSdkV2.Api.Cardmarket

##### Summary

The https://www.cardmarket.com/ information for a given card.

##### Remarks

All prices are in Euros.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketEntry-Prices'></a>
### Prices `property`

##### Summary

Price information for the card.

##### Remarks

All prices are in Euros.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketEntry-UpdatedAt'></a>
### UpdatedAt `property`

##### Summary

A date that the price was last updated. In the format of YYYY/MM/DD

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketEntry-Url'></a>
### Url `property`

##### Summary

The URL to the cardmarket store page to purchase this card.

<a name='T-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice'></a>
## CardmarketPrice `type`

##### Namespace

PokemonTcgSdkV2.Api.Cardmarket

##### Summary

Price information for a card.

##### Remarks

All prices are in Euros.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageDay'></a>
### AverageDay `property`

##### Summary

The average sale price over the last day.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageDayReverseHolo'></a>
### AverageDayReverseHolo `property`

##### Summary

The average sale price over the last day for reverse holos.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageMonth'></a>
### AverageMonth `property`

##### Summary

The average sale price over the last 30 days.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageMonthReverseHolo'></a>
### AverageMonthReverseHolo `property`

##### Summary

The average sale price over the last 30 days for reverse holos.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageSellPrice'></a>
### AverageSellPrice `property`

##### Summary

The average sell price as shown in the chart at the website for non-foils.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageWeek'></a>
### AverageWeek `property`

##### Summary

The average sale price over the last 7 days.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-AverageWeekReverseHolo'></a>
### AverageWeekReverseHolo `property`

##### Summary

The average sale price over the last 7 days for reverse holos.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-GermanProLow'></a>
### GermanProLow `property`

##### Summary

The lowest sell price from German professional sellers.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-LowPrice'></a>
### LowPrice `property`

##### Summary

The lowest price at the market for non-foils.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-LowPriceExPlus'></a>
### LowPriceExPlus `property`

##### Summary

The lowest price at the market for non-foils with condition EX or better.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-ReverseHoloLow'></a>
### ReverseHoloLow `property`

##### Summary

The lowest price at the market as shown at the website (for condition EX+) for reverse holos.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-ReverseHoloSell'></a>
### ReverseHoloSell `property`

##### Summary

The average sell price as shown in the chart at the website for reverse holos.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-ReverseHoloTrend'></a>
### ReverseHoloTrend `property`

##### Summary

The trend price as shown at the website (and in the chart) for reverse holos.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-SuggestedPrice'></a>
### SuggestedPrice `property`

##### Summary

A suggested sell price for professional users, determined by an internal algorithm; this algorithm is controlled by
    cardmarket, not this API.

<a name='P-PokemonTcgSdkV2-Api-Cardmarket-CardmarketPrice-TrendPrice'></a>
### TrendPrice `property`

##### Summary

The trend price as shown at the website (and in the chart) for non-foils.

<a name='T-PokemonTcgSdkV2-Api-FetchableApiObject'></a>
## FetchableApiObject `type`

##### Namespace

PokemonTcgSdkV2.Api

##### Summary

Base class being used for any objects of the API, which can be fetched.

<a name='T-PokemonTcgSdkV2-Api-IApiObjectWithId'></a>
## IApiObjectWithId `type`

##### Namespace

PokemonTcgSdkV2.Api

##### Summary

Represents an object from the API which supports an id.

<a name='P-PokemonTcgSdkV2-Api-IApiObjectWithId-Id'></a>
### Id `property`

##### Summary

String representation of the objects id.

<a name='T-PokemonTcgSdkV2-Api-Cards-Legalities'></a>
## Legalities `type`

##### Namespace

PokemonTcgSdkV2.Api.Cards

##### Summary

The legalities for a given card.

##### Remarks

A legality will not be present in the [Legalities](#T-PokemonTcgSdkV2-Api-Cards-Legalities 'PokemonTcgSdkV2.Api.Cards.Legalities') if it is not legal. If it is legal or banned, it
    will be present.

<a name='P-PokemonTcgSdkV2-Api-Cards-Legalities-Expanded'></a>
### Expanded `property`

##### Summary

The legality ruling for Expanded. Can be either Legal, Banned, or not present.

<a name='P-PokemonTcgSdkV2-Api-Cards-Legalities-Standard'></a>
### Standard `property`

##### Summary

The legality ruling for Standard. Can be either Legal, Banned, or not present.

<a name='P-PokemonTcgSdkV2-Api-Cards-Legalities-Unlimited'></a>
### Unlimited `property`

##### Summary

The legality ruling for Unlimited. Can be either Legal, Banned, or not present.

<a name='T-PokemonTcgSdkV2-Api-Sets-Set'></a>
## Set `type`

##### Namespace

PokemonTcgSdkV2.Api.Sets

##### Summary

Represents a set of Pokémon [Card](#T-PokemonTcgSdkV2-Api-Cards-Card 'PokemonTcgSdkV2.Api.Cards.Card').

<a name='P-PokemonTcgSdkV2-Api-Sets-Set-Images'></a>
### Images `property`

##### Summary

Any images associated with the set, such as symbol and logo.

<a name='P-PokemonTcgSdkV2-Api-Sets-Set-Legalities'></a>
### Legalities `property`

##### Summary

The legalities for a given card.

##### Remarks

A legality will not be present in the [Legalities](#P-PokemonTcgSdkV2-Api-Sets-Set-Legalities 'PokemonTcgSdkV2.Api.Sets.Set.Legalities') if it is not legal. If it is legal or banned, it
    will be present.

<a name='P-PokemonTcgSdkV2-Api-Sets-Set-Name'></a>
### Name `property`

##### Summary

The name of the set.

<a name='P-PokemonTcgSdkV2-Api-Sets-Set-PrintedTotal'></a>
### PrintedTotal `property`

##### Summary

The number printed on the card that represents the total.

##### Remarks

This total does not include secret rares.

<a name='P-PokemonTcgSdkV2-Api-Sets-Set-PtcgoCode'></a>
### PtcgoCode `property`

##### Summary

The code the Pokémon Trading Card Game Online uses to identify a set.

<a name='P-PokemonTcgSdkV2-Api-Sets-Set-ReleaseDate'></a>
### ReleaseDate `property`

##### Summary

The date the set was released (in the USA). Format is YYYY/MM/DD.

<a name='P-PokemonTcgSdkV2-Api-Sets-Set-Series'></a>
### Series `property`

##### Summary

The series the set belongs to, like Sword and Shield or Base.

<a name='P-PokemonTcgSdkV2-Api-Sets-Set-Total'></a>
### Total `property`

##### Summary

The total number of cards in the set, including secret rares, alternate art, etc.

<a name='P-PokemonTcgSdkV2-Api-Sets-Set-UpdatedAt'></a>
### UpdatedAt `property`

##### Summary

The date and time the set was updated. Format is YYYY/MM/DD HH:MM:SS.

<a name='T-PokemonTcgSdkV2-Api-Sets-SetImages'></a>
## SetImages `type`

##### Namespace

PokemonTcgSdkV2.Api.Sets

##### Summary

Any images associated with the set, such as symbol and logo.

<a name='P-PokemonTcgSdkV2-Api-Sets-SetImages-LogoImageUrl'></a>
### LogoImageUrl `property`

##### Summary

The url to the logo image.

<a name='P-PokemonTcgSdkV2-Api-Sets-SetImages-SymbolImageUrl'></a>
### SymbolImageUrl `property`

##### Summary

The url to the symbol image.

<a name='T-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerEntry'></a>
## TcgPlayerEntry `type`

##### Namespace

PokemonTcgSdkV2.Api.TcgPlayer

##### Summary

The https://www.tcgplayer.com information for a given card.

##### Remarks

All prices are in US Dollars.

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerEntry-Prices'></a>
### Prices `property`

##### Summary

Price information for the card.

##### Remarks

All prices are in US Dollars.

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerEntry-UpdatedAt'></a>
### UpdatedAt `property`

##### Summary

A date that the price was last updated. In the format of YYYY/MM/DD

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerEntry-Url'></a>
### Url `property`

##### Summary

The URL to the TCGPlayer store page to purchase this card.

<a name='T-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPrice'></a>
## TcgPlayerPrice `type`

##### Namespace

PokemonTcgSdkV2.Api.TcgPlayer

##### Summary

The price information for card.

##### Remarks

All prices are in US Dollars.

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPrice-DirectLow'></a>
### DirectLow `property`

##### Summary

The direct low price of the card.

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPrice-High'></a>
### High `property`

##### Summary

The high price of the card.

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPrice-Low'></a>
### Low `property`

##### Summary

The low price of the card.

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPrice-Market'></a>
### Market `property`

##### Summary

The market value of the card. This is usually the best representation of what people are willing to pay.

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPrice-Mid'></a>
### Mid `property`

##### Summary

The mid price of the card.

<a name='T-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPriceSet'></a>
## TcgPlayerPriceSet `type`

##### Namespace

PokemonTcgSdkV2.Api.TcgPlayer

##### Summary

Price information for the card.

##### Remarks

All prices are in US Dollars.

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPriceSet-FirstEditionHolofoil'></a>
### FirstEditionHolofoil `property`

##### Summary

The price information for an 1st edition holo foil card type.

##### Remarks

All prices are in US Dollars.

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPriceSet-FirstEditionNormal'></a>
### FirstEditionNormal `property`

##### Summary

The price information for an 1st edition normal card type.

##### Remarks

All prices are in US Dollars.

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPriceSet-HoloFoil'></a>
### HoloFoil `property`

##### Summary

The price information for a holo foil card type.

##### Remarks

All prices are in US Dollars.

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPriceSet-Normal'></a>
### Normal `property`

##### Summary

The price information for a normal card type.

##### Remarks

All prices are in US Dollars.

<a name='P-PokemonTcgSdkV2-Api-TcgPlayer-TcgPlayerPriceSet-ReverseHolofoil'></a>
### ReverseHolofoil `property`

##### Summary

The price information for a reverse hholos foil card type.

##### Remarks

All prices are in US Dollars.

<a name='T-PokemonTcgSdkV2-Api-Cards-WeaknessOrResistance'></a>
## WeaknessOrResistance `type`

##### Namespace

PokemonTcgSdkV2.Api.Cards

##### Summary

Weakness or Resistance for a given card.

<a name='P-PokemonTcgSdkV2-Api-Cards-WeaknessOrResistance-Type'></a>
### Type `property`

##### Summary

The type of weakness or resistance, such as Fire or Water.

<a name='P-PokemonTcgSdkV2-Api-Cards-WeaknessOrResistance-Value'></a>
### Value `property`

##### Summary

The value of the weakness or resistance.
