using System;
using System.Collections.Generic;
using System.Text;

namespace les7
{
    class WinkelKar
    {
        static private List<(string naam, float prijs, int voorraad)> producten;
        static private List<(string naam, float prijs)> winkelkar;

        static void Main(string[] args)
        {
            producten = new List<(string, float, int)> {
                ("Bialetti Moka Express", 22.36F, 5),
                ("Aeropress Coffee Maker", 36.95F, 17),
                ("Hario Skerton Koffiemaler", 43.5F, 7),
                ("Hario V60 Pour Over Kit", 26.95F, 10)
            };
            
            winkelkar = new List<(string, float)> { };
            
            string input = "";
            
            while (input != "q")
            {
                Console.Clear();
                Console.WriteLine("Koffiewinkel- 't Boontje");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
                toonAssortiment();
                toonWinkelkar();

                input = VraagInput();

                if (input == "t")
                {
                    voegToe();
                }
                else if (input == "b")
                {
                    bestellen();
                }
            }
            
            Console.WriteLine("Bye!");
        }

        static void toonAssortiment()
        {
            Console.WriteLine("Assortiment: ");
            for (int i = 0; i < producten.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {producten[i].naam} - {producten[i].prijs} euro - voorraad: {producten[i].voorraad}");
            }
        }

        static void toonWinkelkar()
        {
            Console.WriteLine("\nWinkelkar: ");
            if (winkelkar.Count != 0)
            {

                List<((string naam, float prijs) winkelkar, int count)> optimisedWinkelkar = new List<((string naam, float prijs), int)> { };
                // fill the optimised winkelkar
                for (int i = 0; i < winkelkar.Count; i++)
                {
                    int index = optimisedWinkelkar.FindIndex(item => item.winkelkar.Equals(winkelkar[i]));

                    if (index >= 0)
                    {
                        optimisedWinkelkar[index] = (optimisedWinkelkar[index].winkelkar, optimisedWinkelkar[index].count + 1);
                    } else
                    {
                        optimisedWinkelkar.Add((winkelkar[i], 1));
                    }
                }

                float totalPrice = 0;
                for (int i = 0; i < optimisedWinkelkar.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {optimisedWinkelkar[i].winkelkar.naam} - {optimisedWinkelkar[i].winkelkar.prijs} - aantal: {optimisedWinkelkar[i].count}");
                    totalPrice += optimisedWinkelkar[i].winkelkar.prijs * optimisedWinkelkar[i].count;
                }
                Console.WriteLine("------------------------");
                Console.WriteLine($"TOTAAL: {Math.Round(totalPrice, 2)}");
            } else
            {
                Console.WriteLine("Leeg");
            }
            
        }

        static string VraagInput()
        {
            Console.WriteLine("\nt: Product toevoegen aan winkelwagen");
            Console.WriteLine("b: Bestelling afronden");
            Console.WriteLine("q: Quit");
            
            Console.Write("\nJouw keuze: ");
            return Console.ReadLine();
        }

        static void voegToe()
        {
            Console.Write("\nWelk product wil je toevoegen? (1 - 4): ");
            int productN = leesInt();

            var product = producten[productN - 1];

            if (product.voorraad == 0)
            {
                Console.WriteLine("Product is tijdelijk niet op voorraad.");
                Console.ReadLine();
            } else
            {
                // product toevoegen aan winkelkar
                winkelkar.Add((product.naam, product.prijs));

                // voorraad verminderen met 1
                producten[productN - 1] = (product.naam, product.prijs, product.voorraad - 1);
            }
        }

        static void bestellen()
        {
            Console.Write("Bestelling afronden? (j/n): ");
            string input = Console.ReadLine();

            bool bAfronden = false;
            if (input.ToLower() == "j") bAfronden = true;

            if (bAfronden == true)
            {
                winkelkar.Clear();
            }
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
    }
}
