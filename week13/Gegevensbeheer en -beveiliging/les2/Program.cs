using System;

namespace les2
{
    class Program
    {
        static void Main(string[] args)
        {
            string keuze = "";
            while (keuze.ToLower() != "q")
            {
                Console.Clear();
                ToonMenu();
                keuze = Console.ReadLine();
                switch (keuze)
                {
                    case "1":
                        ProductManager.ProductBeheer();
                        break;
                    case "2":
                        KlantManager.KlantBeheer();
                        break;
                    case "3":
                        BestellingManager.BestellingBeheer();
                        break;
                    case "q":
                        Console.WriteLine("Bye");
                        break;
                    default:
                        Console.WriteLine("Verkeerde keuze");
                        Console.ReadLine();
                        break;
                }
            }

        }

        static void ToonMenu()
        {
            Console.WriteLine("Product Manager");
            Console.WriteLine("===============");
            Console.WriteLine("1. Product Beheer");
            Console.WriteLine("2. Klant Beheer");
            Console.WriteLine("3. Bestelling Beheer");
            Console.WriteLine("q. Stop");

            Console.Write("\nJouw keuze? ");
        }
    }
}
    