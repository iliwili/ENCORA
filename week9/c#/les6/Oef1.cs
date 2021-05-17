using System;
using System.Collections.Generic;

namespace les6
{
    class Oef1
    {
        static private List<(string naam, float prijs, bool promo, int voorraad, int leeftijd)> productList;

        static void Main(string[] args)
        {
            productList = new List<(
             string naam,
             float prijs,
             bool promo,
             int voorraad,
             int leeftijd)>
            {
             ("Catan", 41.99F, false, 2, 10),
             ("Carcassonne", 27.99F, true, 3, 8),
             ("Uno", 9.99F, false, 5, 7),
             ("Scrabble", 39.99F, false, 3, 10),
             ("Pietjesbak", 14.99F, true, 2, 8)
            };

            string input = "";

            while (input != "q")
            {
                Console.Clear();
                ToonProducten(productList);

                input = VraagInput();

                if (input == "1")
                {
                    AddProduct(productList);
                } else if (input == "2")
                {
                    ReadProduct(productList);
                } else if (input == "3")
                {
                    UpdateProduct(productList);
                } else if (input == "4")
                {
                    DeleteProduct(productList);
                }
            }
        }

        static string VraagInput()
        {
            Console.WriteLine("\n1. Create");
            Console.WriteLine("2. Read");
            Console.WriteLine("3. Update");
            Console.WriteLine("4. Delete");
            Console.WriteLine("q. Stop");

            Console.Write("\nYour choice: ");
            return Console.ReadLine();
        }

        static void ToonProducten(List<(string naam, float prijs, bool promo, int voorraad, int leeftijd)> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                var product = list[i];

                Console.Write($"{i+1}. {product.naam} (age {product.leeftijd}+) kost ");
                ToonPrijs(product.prijs, product.promo);
                Console.Write($") , er zijn er { product.voorraad} in voorraad.");
                Console.WriteLine();
            }
        }

        static void ToonProduct((string naam, float prijs, bool promo, int voorraad, int leeftijd) product)
        {
            Console.Write($"{product.naam} (age {product.leeftijd}+) kost ");
            ToonPrijs(product.prijs, product.promo);
            Console.Write($") , er zijn er { product.voorraad} in voorraad.");
            Console.WriteLine();
        }

        static void ToonPrijs(float prijs, bool promo)
        {
            double promoPrijs = prijs * 0.20;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write($"{prijs}");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" (promo: ");
            if (promo)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write($"{Math.Round(promoPrijs, 3)}");
                Console.BackgroundColor = ConsoleColor.Black;
            } else
            {
                Console.Write("geen");
            }

        }
        
        static void AddProduct(List<(string naam, float prijs, bool promo, int voorraad, int leeftijd)> list)
        {
            Console.Write("Naam:");
            string naam = Console.ReadLine();

            Console.Write("Prijs");
            float prijs = float.Parse(Console.ReadLine());

            Console.Write("Promo (j/n): ");
            string rPromo = Console.ReadLine();
            bool promo = false;

            if (rPromo == "j")
            {
                promo = true;
            }

            Console.Write("Voorraad: ");
            int voorraad = int.Parse(Console.ReadLine());

            Console.WriteLine("Leeftijd: ");
            int leeftijd = int.Parse(Console.ReadLine());

            list.Add((naam, prijs, promo, voorraad, leeftijd));
        }

        static void ReadProduct(List<(string naam, float prijs, bool promo, int voorraad, int leeftijd)> list)
        {
            Console.Write("\nWhich product you want to read? ");
            int nProduct= int.Parse(Console.ReadLine());

            ToonProduct(list[nProduct-1]);

            Console.ReadLine();
        }

        static void UpdateProduct(List<(string naam, float prijs, bool promo, int voorraad, int leeftijd)> list)
        {
            Console.Write("\nWhich product you want to update? ");
            int nProduct = int.Parse(Console.ReadLine());
            

            string name = list[nProduct - 1].naam;
            float price = list[nProduct - 1].prijs;
            bool promo = list[nProduct - 1].promo;
            int stock = list[nProduct - 1].voorraad;
            int age = list[nProduct - 1].leeftijd;

            string input = "";
            Console.Clear();
            while (input != "q")
            {
                ToonProduct(list[nProduct - 1]);
                input = VraagUpdateProductInput();

                if (input == "1")
                {
                    Console.WriteLine($"Huidig: {list[nProduct - 1].naam}");
                    Console.Write("Nieuw: ");
                    string newName = Console.ReadLine();

                    list[nProduct - 1] = (newName, price, promo, stock, age); 
                } else if (input == "2")
                {
                    Console.WriteLine($"Huidig: {list[nProduct - 1].prijs}");
                    Console.Write("Nieuw: ");
                    float newPrice = float.Parse(Console.ReadLine());

                    list[nProduct - 1] = (name, newPrice, promo, stock, age);
                } else if (input == "3")
                {
                    Console.WriteLine($"Huidig: {list[nProduct - 1].promo}");
                    Console.Write("Nieuw: ");
                    bool newPromo = bool.Parse(Console.ReadLine());

                    list[nProduct - 1] = (name, price, newPromo, stock, age);
                } else if (input == "4")
                {
                    Console.WriteLine($"Huidig: {list[nProduct - 1].voorraad}");
                    Console.Write("Nieuw: ");
                    int newStock = int.Parse(Console.ReadLine());

                    list[nProduct - 1] = (name, price, promo, newStock, age);
                } else if (input == "5")
                {
                    Console.WriteLine($"Huidig: {list[nProduct - 1].leeftijd}");
                    Console.Write("Nieuw: ");
                    int newAge = int.Parse(Console.ReadLine());

                    list[nProduct - 1] = (name, price, promo, stock, newAge);
                }
                Console.Clear();
            }
        }

        static string VraagUpdateProductInput()
        {
            Console.WriteLine("\n1. Naam");
            Console.WriteLine("2. Prijs");
            Console.WriteLine("3. Promo");
            Console.WriteLine("4. Voorraad");
            Console.WriteLine("5. Leeftijd");
            Console.WriteLine("q. Stop");

            Console.Write("\nYour choice: ");
            return Console.ReadLine();
        }

        static void DeleteProduct(List<(string naam, float prijs, bool promo, int voorraad, int leeftijd)> list)
        {
            Console.Write("\nWhich product you want to delete? ");
            int nProduct = int.Parse(Console.ReadLine());

            list.RemoveAt(nProduct-1);
        }
    }
}
