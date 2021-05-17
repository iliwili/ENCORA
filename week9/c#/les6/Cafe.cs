using System;
using System.Collections.Generic;
using System.Text;

namespace les6
{
    class Cafe
    {
        static private List<(string naam, float prijs)> dranken;
        static private List<(int tafel, string naam, float prijs)> bestellingen;
        private const int nTafels = 9;

        static void Main(string[] args)
        {
            dranken = new List<(string naam, float prijs)> {
                ("Fanta", 2),
                ("Fristi", 2.5F),
                ("Chocomelk", 1.5F),
                ("Koffie", 1),
                ("Thee citroen", 1.75F),
                ("Capri-Sun", 1)
            };
            bestellingen = new List<(int tafel, string naam, float prijs)> { };

            string input = "";

            while (input != "q")
            {
                Console.Clear();
                ToonDrankenEnBestellingen(dranken, bestellingen);
                input = VraagInputBestellingen();

                if (input == "1")
                {
                    AddBestelling(dranken, bestellingen);
                } else if (input == "2")
                {
                    BestellingAfrekenen(bestellingen);
                }
            }
        }


        static void ToonDrankenEnBestellingen(List<(string naam, float prijs)> dList, List<(int tafel, string naam, float prijs)> bList)
        {
            Console.WriteLine("Cafe Sport");
            Console.WriteLine("**********");
            for (int i = 0; i < dList.Count; i++)
            {
                Console.WriteLine($"{i+1}. {dList[i].naam}, {dList[i].prijs}");
            }

            Console.WriteLine("\n");

            for (int i = 0; i < bList.Count; i++)
            {
                Console.WriteLine($"Tafelnummer {bList[i].tafel} heeft een {bList[i].naam} besteld.");
            }
            Console.WriteLine("");
        }

        static string VraagInputBestellingen()
        {
            Console.WriteLine("1. Nieuw bestelling");
            Console.WriteLine("2. Afrekenen");

            Console.Write("\nJe keuze (1, 2 of q om te stoppen): ");
            return Console.ReadLine();
        }

        static void AddBestelling(List<(string naam, float prijs)> dList, List<(int tafel, string naam, float prijs)> bList)
        {
            Console.Write("Geef tafelnummer: ");
            int nTafel = int.Parse(Console.ReadLine());

            Console.Write("Geef dranknummer: ");
            int nDrank = int.Parse(Console.ReadLine());

            bList.Add((nTafel, dList[nDrank-1].naam, dList[nDrank-1].prijs));
        }

        static void BestellingAfrekenen(List<(int tafel, string naam, float prijs)> bList)
        {
            Console.Write("Geef het tafelnummer: ");
            int nTafel = int.Parse(Console.ReadLine());

            float prijs = 0;

            for (int i = 0; i < bList.Count; i++)
            {
                if (bList[i].tafel == nTafel)
                {
                    Console.WriteLine($"Tafelnummer {bList[i].tafel} heeft een {bList[i].naam} besteld.");
                    prijs += bList[i].prijs;
                }
            }
            Console.WriteLine($"Totaal: {prijs} euro");

            Console.Write("\nAfrekenen (dit verwijdert al de bestelinngen van deze tafel) (y/n)? ");
            string yn = Console.ReadLine();

            if (yn == "y")
            {
                Console.WriteLine("Afgerekend!");
                for (int i = 0; i < bList.Count; i++)
                {
                    if (bList[i].tafel == nTafel)
                    {
                        bList.Remove(bList[i]);
                    }
                }
                Console.ReadLine();
            }
        }
    }
}
