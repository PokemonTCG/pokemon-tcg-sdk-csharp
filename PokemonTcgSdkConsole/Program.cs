using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonTcgSdk;
using PokemonTcgSdk.Models;
using Newtonsoft.Json;

namespace PokemonTcgSdkConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //FindCard();
            //GetCards();
            GetCardsWithArgs();
            Console.ReadLine();
        }

        static void FindCard()
        {
            PokemonCard card = Card.Find<PokemonCard>("base4-4");
            Console.WriteLine(JsonConvert.SerializeObject(card, Formatting.Indented));
        }

        static void GetCards()
        {
            PokemonCardObject card = Card.Get<PokemonCardObject>("cards");
            Console.WriteLine(JsonConvert.SerializeObject(card, Formatting.Indented));
        }

        static void GetCardsWithArgs()
        {
            Dictionary<string, string> args = new Dictionary<string, string>();
            args.Add("supertype", "trainer");
            args.Add("pageSize", "10");

            TrainerCardObject card = Card.Get<TrainerCardObject>("cards", args);
            Console.WriteLine(JsonConvert.SerializeObject(card, Formatting.Indented));
        }
    }
}
