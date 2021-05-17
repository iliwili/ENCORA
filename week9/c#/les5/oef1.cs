using System;
using System.Collections.Generic;

namespace les5
{
    class oef1
    {
        static private List<(string merk, string model, int bouwjaar, int nDeuren, string type)> carList;

        static void Main(string[] args)
        {
            carList = new List<(string merk, string model, int bouwjaar, int nDeuren, string type)>
            {
                ("Volvo", "66", 1975, 2, "sedan"),
                ("Fiat", "Panda", 1981, 3, "hatchback"),
                ("BMW", "732i", 1979, 3, "sedan"),
                ("Volvo", "265", 1980, 5, "wagon"),
                ("Volvo", "340", 1982, 5, "hatchback"),
                ("BMW", "525", 1974, 4, "sedan")
            };

            string input = "";

            while (input  != "q")
            {
                Console.Clear();
                printAutos(carList);

                input = VraagInput();

                if (input == "1")
                {
                    addCar(carList);
                } else if (input == "2")
                {
                    removeCar(carList);
                }
            }
        }


        static void printAutos(List<(string merk, string model, int bouwjaar, int nDeuren, string type)> autos)
        {
            for (int i = 0; i < autos.Count; i++)
            {
                var auto = autos[i];
                Console.WriteLine($"{i+1}. De {auto.merk} {auto.model} is een {auto.nDeuren}-deurs {auto.type} en werd voor het eerst gebouwd in {auto.bouwjaar}.");
            }
        }

        static string VraagInput()
        {
            Console.WriteLine("\n1. Voeg een auto toe");
            Console.WriteLine("2. Verwijder een auto");
            Console.WriteLine("q. Stop");

            Console.Write("\nJouw keuze: ");
            return Console.ReadLine();
        }

        static void addCar(List<(string merk, string model, int bouwjaar, int nDeuren, string type)> autos)
        {
            Console.Clear();
            Console.Write("Auto merk: ");
            string newMerk = Console.ReadLine();

            Console.Write("Auto model: ");
            string newModel = Console.ReadLine();

            Console.Write("Auto bouwjaar: ");
            int newBouwjaar = int.Parse(Console.ReadLine());

            Console.Write("Aantal deuren: ");
            int newNDeuren= int.Parse(Console.ReadLine());
            
            Console.Write("Aantal deuren: ");
            string newType= Console.ReadLine();

            autos.Add((newMerk, newModel, newBouwjaar, newNDeuren, newType));
        }

        private static void removeCar(List<(string merk, string model, int bouwjaar, int nDeuren, string type)> carList)
        {
            Console.Clear();
            printAutos(carList);

            Console.Write("\nWhich car would you like to remove? ");
            int number = int.Parse(Console.ReadLine());

            carList.RemoveAt(number - 1);
        }
    }
}
