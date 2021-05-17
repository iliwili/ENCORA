using System;
using System.Collections.Generic;

class Program
{
    static private List<(string naam, float prijs, bool promo, int voorraad, int leeftijd)> productList;

    static void Main(string[] args)
    {
        productList = new List<(
            string,
            float,
            bool,
            int,
            int)>
        {
            ("Catan", 41.99F, false, 2, 10),
            ("Carcassonne", 27.99F, true, 3, 8),
            ("Uno", 9.99F, false, 5, 7),
            ("Scrabble", 39.99F, false, 3, 7),
            ("Pietjesbak", 14.99F, true, 2, 8),

        };

        string input = "";

        while(input != "q")
        {
            Console.Clear();
            Console.WriteLine("Gezelschapspellen De Ork");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
            ToonProducten();
            Console.Write("\na: add, c: change, l: less than 3, q: quit: (a, c, l or q?) ");
            input = Console.ReadLine();

            if(input == "a")
            {
                AddProduct();
            }
            else if (input == "c")
            {
                ChangeProduct();
            }
            else if (input == "l")
            {
                MinderDan3();
            }
        }
    }

    static void ToonProducten()
    {
        for(int i = 0; i < productList.Count; i++)
        {
            Console.Write($"{i+1}. {productList[i].naam} - {productList[i].prijs} euro - ");

            if(productList[i].promo)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write("in promo");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.Write("niet in promo");
            }
            
            Console.WriteLine($" - vanaf {productList[i].leeftijd} jaar - voorraad: {productList[i].voorraad}");
            
        }
    }

    static void MinderDan3()
    {
        Console.WriteLine("Minder dan 3 op voorraad:");
        for (int i = 0; i < productList.Count; i++)
        {
            if(productList[i].voorraad < 3)
            {
                Console.Write($"{i + 1}. {productList[i].naam} - {productList[i].prijs} euro - ");
                if (productList[i].promo)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write("in promo");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.Write("niet in promo");
                }

                Console.WriteLine($" - vanaf {productList[i].leeftijd} jaar - voorraad: {productList[i].voorraad}");
            }
        }
        Console.ReadLine();
    }

    static void AddProduct()
    {
        Console.Write("Geef naam: ");
        string naam = Console.ReadLine();

        Console.Write("Geef prijs: ");
        float prijs = leesFloat();

        Console.Write("In promo (j/n): ");
        string strpromo = Console.ReadLine();

        Console.Write("Voorraad: ");
        int voorraad = leesInt();

        Console.Write("Vanaf leeftijd: ");
        int leeftijd = leesInt(16);

        bool boolpromo = false;
        if (strpromo.ToLower() == "j") boolpromo = true;

        productList.Add((naam, prijs, boolpromo, voorraad, leeftijd));

        //productList.Add((naam, prijs, strpromo == "j" ? true : false, voorraad, leeftijd));

    }

    static void ChangeProduct()
    {
        Console.Write("Welk product wil je veranderen (geef het nummer): ");
        int n = leesInt(productList.Count);

        Console.Write($"Geef nieuwe naam voor {productList[n-1].naam} (leeg om te behouden): ");
        string naam = Console.ReadLine();
        if (naam == "") naam = productList[n-1].naam;

        Console.Write("Geef prijs: ");
        float prijs = leesFloat();

        Console.Write("In promo (j/n): ");
        string strpromo = Console.ReadLine();

        Console.Write("Voorraad: ");
        int voorraad = leesInt();

        Console.Write("Vanaf leeftijd: ");
        int leeftijd = leesInt(16);

        bool boolpromo = false;
        if (strpromo.ToLower() == "j") boolpromo = true;

        productList[n - 1] = ((naam, prijs, boolpromo, voorraad, leeftijd));

        //productList[n-1] = ((naam, prijs, strpromo == "j" ? true : false, voorraad, leeftijd));
    }

    static int leesInt()
    {
        string input = Console.ReadLine(); ;
        int result = -1;

        while (!int.TryParse(input, out result) || result < 1)
        {
            Console.Write($"Geef een positief geheel getal in: ");
            input = Console.ReadLine();
        }
        return result;
    }

    static int leesInt(int max)
    {
        string input = Console.ReadLine();
        int result = -1;

        while (!int.TryParse(input, out result) || result < 1 || result > max)
        {
            Console.Write($"Geef een positief geheel getal in kleiner dan {max+1}: ");
            input = Console.ReadLine();
        }
        return result;
    }

    static float leesFloat()
    {
        string input = Console.ReadLine();
        float result = -1;

        while (!float.TryParse(input, out result) || result < 1)
        {
            Console.Write($"Geef een positief getal in: ");
            input = Console.ReadLine();
        }
        return result;
    }
}