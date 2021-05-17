using System;
using System.Collections.Generic;
using System.Text;

namespace les2
{
    class refactoringOppervlakte
    {
        static void Main(string[] args)
        {
            string keuze = "";

            while (keuze != "s")
            {
                keuze = ToonMenuEnVraagInput();

                if (keuze == "1")
                {
                    OppervlakteRechthoek();
                }
                else if (keuze == "2")
                {
                    OppervlakteDriehoek();
                }
                else if (keuze == "3")
                {
                    OppervlakteCirkel();
                }
                else if (keuze == "s")
                {
                    Console.WriteLine("Tot de volgende keer!");
                    continue;
                } else
                {
                    Console.WriteLine("Ongeldige keuze :(");
                    Console.ReadLine();
                }

                Console.WriteLine("Druk enter om terug te gaan naar het hoofdmenu.");
                Console.ReadLine();
            }
        }

        static string ToonMenuEnVraagInput()
        {
            Console.WriteLine("OPPERVLAKTE BEREKENEN");
            Console.WriteLine("=====================");
            Console.WriteLine("1. Berekenen oppervlakte rechthoek");
            Console.WriteLine("2. Berekenen oppervlakte driehoek");
            Console.WriteLine("3. Berekenen oppervlakte cirkel");
            Console.WriteLine("4. Stop\n");

            Console.Write("Jouw keuze (1, 2, 3 of s) ? ");
            return Console.ReadLine();
        }

        static void OppervlakteRechthoek()
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

        static void OppervlakteDriehoek()
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

        static void OppervlakteCirkel()
        {
            Console.Clear();
            Console.WriteLine("\nOPPERVLAKTE CIRKEL BEREKENEN");
            Console.WriteLine("==============================");

            Console.Write("Geef de straal in cm: ");
            double straal = float.Parse(Console.ReadLine());

            double oppervlakte = straal * straal * Math.PI;
            Console.WriteLine("De oppervlakte is: " + Math.Round(oppervlakte, 2) + "cm \n");
        }
    }
}
