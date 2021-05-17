using System;

namespace oef5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Frank's help-programma");
            Console.WriteLine("______________________");

            int dag = 1;
            float neerslagTotaal = 0;
            float neerslag = 0;

            while (neerslag >= 0)
            {
                Console.Write("Geef de neerslag voor dag " + dag + " in mm: ");
                neerslag = float.Parse(Console.ReadLine());

                if (neerslag >= 0)
                {
                    neerslagTotaal += neerslag;
                    dag += 1;
                }

            }

            Console.WriteLine("\nDe gemiddelde neerslag was " + (neerslagTotaal / (dag - 1)) + " mm");
        }
    }
}
