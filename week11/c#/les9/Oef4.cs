using System;
using System.Collections.Generic;
using System.Text;

namespace les9
{
    class Oef4
    {
        static void Main(string[] args)
        {
            Boek boek = new Boek();
            boek.SchudBoek();

            Kaart gKaart; // de getrokken kaart
            Kaart tKaart; // de te trekken kaart
            
            int pScore = 0;
            int nScore = 0;

            string message = "";

            gKaart = boek.TrekEnVerwijderEersteKaart();

            for (int i = 0; i < boek.kaarten.Count; i++)
            {
                Console.Clear();
                Console.WriteLine("HOGER OF LAGER?");
                Console.WriteLine("~~~~~~~~~~~~~~~");
                Console.Write("KAART: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(gKaart);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (message != "")
                {
                    Console.WriteLine(message);
                }
                Console.WriteLine($"Jouw score: {nScore}/{pScore}.");
                Console.Write("Denk je dat de volgende kaart hoger (of gelijk) of lager zal zijn? (type h of l): ");
                string keuze = Console.ReadLine();

                tKaart = boek.TrekEnVerwijderEersteKaart();

                if (tKaart.BerekenWaarde() >= gKaart.BerekenWaarde())
                {
                    message = "De kaart was hoger!";
                    if (keuze == "h")
                    {
                        pScore++;
                    } else
                    {
                        nScore++;
                    }
                } else
                {
                    message = "De kaart was lager!";
                    if (keuze == "l")
                    {
                        pScore++;
                    }
                    else
                    {
                        nScore++;
                    }
                }

                gKaart = tKaart;
            }
        }
    }
}
