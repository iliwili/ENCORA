using System;
using System.Collections.Generic;
using System.Text;

namespace les8
{
    class AutoApp
    {
        static public List<Auto> Autos;
        
        static void Main(string[] args)
        {
            Autos = new List<Auto> {
                new Auto("Volvo", "66", 1975, 2, "sedan"),
                new Auto("Fiat", "Panda", 1981, 3, "hatchback")
            };

            string input = "";

            while (input != "q")
            {
                Console.Clear();
                ToonAutos();

                input = VraagLijst();

                if (input == "1")
                {
                    VoegAutoToe();
                }
                else if (input == "2")
                {
                    WijzigAuto();
                } else if (input == "3")
                {
                    VerwijderAuto();
                }
            }


        }

        static string VraagLijst()
        {
            Console.WriteLine("1. Voeg een auto toe");
            Console.WriteLine("2. Wijzig een auto");
            Console.WriteLine("3. Verwijder een auto");
            Console.WriteLine("q. Quit ");

            Console.Write("Jouw keuze (1,2,3,q): ");
            return Console.ReadLine();
        }

        static void VoegAutoToe()
        {
            Console.Write("Naam: ");
            string naam = Console.ReadLine();
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Bouwjaar: ");
            string strBouwjaar = Console.ReadLine();
            int bouwjaar;
            while (!int.TryParse(strBouwjaar, out bouwjaar))
            {
                Console.Write("Foutieve invoer. Bouwjaar: ");
                strBouwjaar = Console.ReadLine();
            }
            Console.Write("Aantal deuren: ");
            string strNDeuren = Console.ReadLine();
            int nDeuren;
            while (!int.TryParse(strNDeuren, out nDeuren))
            {
                Console.Write("Foutieve invoer. Aantal deuren: ");
                strNDeuren = Console.ReadLine();
            }
            Console.Write("Type: ");
            string type = Console.ReadLine();
            Autos.Add(new Auto(naam, model, bouwjaar, nDeuren, type));
        }

        static void ToonAutos()
        {
            for (int i = 0; i < Autos.Count; i++)
            {
                Console.Write(i+1 + " " );
                PrintAuto(i);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintAuto(int nAuto)
        {
            Console.Write(Autos[nAuto].Merk + " " + Autos[nAuto].Model + ", " + Autos[nAuto].NDeuren + " deurs " + Autos[nAuto].Type +  ", bouwjaar " + Autos[nAuto].Bouwjaar);
        }

        static void WijzigAuto()
        {
            Console.Write("\nWelke auto: ");
            string strNAuto = Console.ReadLine();
            int nAuto;
            while (!int.TryParse(strNAuto, out nAuto))
            {
                Console.Write("Foutieve invoer. Welke auto: ");
                strNAuto = Console.ReadLine();
            }

            string strEigenschap = "";

            while (strEigenschap != "q")
            {
                Console.Clear();

                Console.Write("WIJZIG AUTO: ");
                PrintAuto(nAuto - 1);
                Console.WriteLine();

                Console.WriteLine("\n1. Merk");
                Console.WriteLine("2. Model");
                Console.WriteLine("3. Bouwjaar");
                Console.WriteLine("4. Aantal deuren");
                Console.WriteLine("5. Type");
                Console.WriteLine("q. Quit");

                Console.Write("\nWat wil je veranderen? (1,2,3,4,5,q): ");
                strEigenschap = Console.ReadLine();

                if (strEigenschap == "1")
                {
                    Console.Write("\nGeef een merk in: ");
                    string merk = Console.ReadLine();

                    Autos[nAuto - 1].Merk = merk;
                }
                else if (strEigenschap == "2")
                {
                    Console.Write("\nGeef een model in: ");
                    string model = Console.ReadLine();

                    Autos[nAuto - 1].Model = model;
                }
                else if (strEigenschap == "3")
                {
                    Console.Write("Geef het bouwjaar: ");
                    string strBouwjaar = Console.ReadLine();
                    int nBouwjaar;
                    while (!int.TryParse(strBouwjaar, out nBouwjaar))
                    {
                        Console.Write("Foutieve invoer. Geef het bouwjaar: ");
                        strBouwjaar = Console.ReadLine();
                    }

                    Autos[nAuto - 1].Bouwjaar = nBouwjaar;
                }
                else if (strEigenschap == "4")
                {
                    Console.Write("Geef het aantal deuren: ");
                    string strNDeuren = Console.ReadLine();
                    int nDeuren;

                    while (!int.TryParse(strNDeuren, out nDeuren))
                    {
                        Console.Write("Foutieve invoer. Geef aantal deuren: ");
                        strNDeuren = Console.ReadLine();
                    }

                    Autos[nAuto - 1].NDeuren = nDeuren;
                }
                else if (strEigenschap == "5")
                {
                    Console.Write("Geef het type: ");
                    string type = Console.ReadLine();

                    Autos[nAuto - 1].Type = type;
                }
            }
        }

        static void VerwijderAuto()
        {
            Console.Write("\nWelke auto wil je verwijderen: ");
            string strNAuto = Console.ReadLine();
            int nAuto;
            while (!int.TryParse(strNAuto, out nAuto))
            {
                Console.Write("Foutieve invoer. Welke auto: ");
                strNAuto = Console.ReadLine();
            }

            Autos.RemoveAt(nAuto-1);
        }
    }

}
