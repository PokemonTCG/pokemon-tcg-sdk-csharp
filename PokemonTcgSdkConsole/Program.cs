using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PokemonTcgSdk;
using PokemonTcgSdk.Models;

namespace PokemonTcgSdkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindPokemonCard();
            //GetPokemonCards();
            //GetTrainerCardsWithArgs();
            //FindTrainerCard();
            //GetSetCards();
            //FindSet();
            //GetTypes();
            //GetSuperTypes();
            //GetSubTypes();
            Console.ReadLine();
        }

        static void FindPokemonCard()
        {
            Pokemon card = Card.Find<Pokemon>(ResourceTypes.Cards, "base4-4");
            Console.WriteLine(JsonConvert.SerializeObject(card, Formatting.Indented));
        }

        static void FindTrainerCard()
        {
            Trainer card = Card.Find<Trainer>(ResourceTypes.Cards, "xy7-79");
            Console.WriteLine(JsonConvert.SerializeObject(card, Formatting.Indented));
        }

        static void GetPokemonCards()
        {
            Pokemon card = Card.Get<Pokemon>(ResourceTypes.Cards);
            Console.WriteLine(JsonConvert.SerializeObject(card, Formatting.Indented));
        }

        static void GetTrainerCardsWithArgs()
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add(CardQueryTypes.SuperType, "trainer");
            args.Add(CardQueryTypes.PageSize, "1");

            Trainer card = Card.Get<Trainer>(ResourceTypes.Cards, args);
            Console.WriteLine(JsonConvert.SerializeObject(card, Formatting.Indented));
        }

        static void GetSetCards()
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add(SetQueryTypes.Name, "Base");
            args.Add(SetQueryTypes.PageSize, "1");

            Set set = Sets.Get<Set>(ResourceTypes.Sets, args);
            Console.WriteLine(JsonConvert.SerializeObject(set, Formatting.Indented));
        }

        static void FindSet()
        {
            Set set = Sets.Find<Set>(ResourceTypes.Sets, "base1");
            Console.WriteLine(JsonConvert.SerializeObject(set, Formatting.Indented));
        }

        static void GetTypes()
        {
            TypeData type = Types.Get<TypeData>(ResourceTypes.Types);
            Console.WriteLine(JsonConvert.SerializeObject(type, Formatting.Indented));
        }

        static void GetSuperTypes()
        {
            SuperType type = SuperTypes.Get<SuperType>(ResourceTypes.SuperTypes);
            Console.WriteLine(JsonConvert.SerializeObject(type, Formatting.Indented));
        }

        static void GetSubTypes()
        {
            SubType type = SubTypes.Get<SubType>(ResourceTypes.SubTypes);
            Console.WriteLine(JsonConvert.SerializeObject(type, Formatting.Indented));
        }
    }
}
