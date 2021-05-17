using System;

namespace oef4
{
    class oef4
    {
        static void Main(string[] args)
        {
            string keuze = "";

            while (keuze != "s")
            {
                Console.WriteLine("OPPERVLAKTE BEREKENEN");
                Console.WriteLine("=====================");
                Console.WriteLine("1. Berekenen oppervlakte rechthoek");
                Console.WriteLine("2. Berekenen oppervlakte driehoek");
                Console.WriteLine("3. Berekenen oppervlakte cirkel");
                Console.WriteLine("4. Stop\n");

                Console.Write("Jouw keuze (1, 2, 3 of s) ? ");
                keuze = Console.ReadLine();

                if (keuze == "1")
                {
                    Console.Clear();
                    Console.WriteLine("\nOPPERVLAKTE RECHTHOEK BEREKENEN");
                    Console.WriteLine("===============================");

                    Console.Write("Geef de breedte in cm: ");
                    float breedte = float.Parse(Console.ReadLine());

                    Console.Write("Geef de lengte in cm: ");
                    float lengte = float.Parse(Console.ReadLine());

                    float oppervlakte = breedte * lengte;
                    Console.WriteLine("De oppervlakte is: " + oppervlakte + "cm \n");
                }
                else if (keuze == "2")
                {
                    Console.Clear();
                    Console.WriteLine("\nOPPERVLAKTE DRIEHOEK BEREKENEN");
                    Console.WriteLine("==============================");

                    Console.Write("Geef de basis in cm: ");
                    float basis = float.Parse(Console.ReadLine());

                    Console.Write("Geef de hoogte in cm: ");
                    float hoogte = float.Parse(Console.ReadLine());

                    float oppervlakte = (basis * hoogte) / 2;
                    Console.WriteLine("De oppervlakte is: " + oppervlakte + "cm \n");
                }
                else if (keuze == "3")
                {
                    Console.Clear();
                    Console.WriteLine("\nOPPERVLAKTE CIRKEL BEREKENEN");
                    Console.WriteLine("==============================");

                    Console.Write("Geef de straal in cm: ");
                    double straal = float.Parse(Console.ReadLine());

                    double oppervlakte = straal * straal * Math.PI;
                    Console.WriteLine("De oppervlakte is: " + Math.Round(oppervlakte, 2) + "cm \n");
                }
                else
                {
                    continue;
                }

                Console.WriteLine("Druk enter om terug te gaan naar het hoofdmenu.");
                Console.ReadLine();
            }
        }
    }
}
