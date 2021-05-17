using System;

namespace AppLes1
{
    class Program
    {
        static void Main(string[] args)
        {
            // OEFENING 2
            /*Console.WriteLine("OPPERVLAKTE RECHTHOEK BEREKENEN");
            Console.WriteLine("===============================");

            Console.Write("Geef de breedte in cm: ");
            float breedte = float.Parse(Console.ReadLine());

            Console.Write("Geef de lengte in cm: ");
            float lengte = float.Parse(Console.ReadLine());

            float oppervlakte = breedte * lengte;
            Console.WriteLine("De oppervlakte is: " + oppervlakte + "cm \n");

            Console.WriteLine("OPPERVLAKTE DRIEHOEK BEREKENEN");
            Console.WriteLine("==============================");

            Console.Write("Geef de basis in cm: ");
            float basis = float.Parse(Console.ReadLine());

            Console.Write("Geef de hoogte in cm: ");
            float hoogte = float.Parse(Console.ReadLine());

            float oppervlakte = (basis * hoogte) / 2;
            Console.WriteLine("De oppervlakte is: " + oppervlakte + "cm \n");*/

            // OEFENING 3
            /*Console.WriteLine("OPPERVLAKTE BEREKENEN");
            Console.WriteLine("=====================");
            Console.WriteLine("1. Berekenen oppervlakte rechthoek");
            Console.WriteLine("2. Berekenen oppervlakte driehoek\n");

            Console.Write("Jouw keuze (1 of 2) ?");
            int keuze = int.Parse(Console.ReadLine());

            if (keuze == 1)
            {
                Console.WriteLine("\nOPPERVLAKTE RECHTHOEK BEREKENEN");
                Console.WriteLine("===============================");

                Console.Write("Geef de breedte in cm: ");
                float breedte = float.Parse(Console.ReadLine());

                Console.Write("Geef de lengte in cm: ");
                float lengte = float.Parse(Console.ReadLine());

                float oppervlakte = breedte * lengte;
                Console.WriteLine("De oppervlakte is: " + oppervlakte + "cm \n");
            } else if (keuze == 2)
            {
                Console.WriteLine("\nOPPERVLAKTE DRIEHOEK BEREKENEN");
                Console.WriteLine("==============================");

                Console.Write("Geef de basis in cm: ");
                float basis = float.Parse(Console.ReadLine());

                Console.Write("Geef de hoogte in cm: ");
                float hoogte = float.Parse(Console.ReadLine());

                float oppervlakte = (basis * hoogte) / 2;
                Console.WriteLine("De oppervlakte is: " + oppervlakte + "cm \n");
            } else
            {
                Console.WriteLine("Foute keuze :(");
            }*/

            // OEFENING 4
           /* string keuze = "";

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
                } else if (keuze == "2")
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
                } else if (keuze == "3")
                {
                    Console.Clear();
                    Console.WriteLine("\nOPPERVLAKTE CIRKEL BEREKENEN");
                    Console.WriteLine("==============================");

                    Console.Write("Geef de straal in cm: ");
                    double straal = float.Parse(Console.ReadLine());

                    double oppervlakte = straal * straal * Math.PI;
                    Console.WriteLine("De oppervlakte is: " + Math.Round(oppervlakte, 2) + "cm \n");
                } else
                {
                    continue;
                }

                Console.WriteLine("Druk enter om terug te gaan naar het hoofdmenu.");
                Console.ReadLine();
            }*/


            // OEFENING 5
            Console.WriteLine("Frank's help-programma");
            Console.WriteLine("______________________");

            int dag = 1;
            float neerslagTotaal = 0;
            float neerslag = 0;

            while (neerslag >= 0) {
                Console.Write("Geef de neerslag voor dag " + dag + " in mm: ");
                neerslag = float.Parse(Console.ReadLine());

                if (neerslag >= 0)
                {
                    neerslagTotaal += neerslag;
                    dag += 1;
                }

            }

            Console.WriteLine("\nDe gemiddelde neerslag was " + (neerslagTotaal / (dag-1)) + " mm");

        }
    }
}
