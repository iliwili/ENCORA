using System;

namespace oef6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("REKENEN");

            string keuze = "";

            while (keuze != "stop") {
                Console.WriteLine("1. Optellen");
                Console.WriteLine("2. Aftrekken");
                Console.WriteLine("3. Vermenigvuldigen");
                Console.WriteLine("4. Delen");
                Console.WriteLine("5. Stop\n");

                Console.Write("Geef je keuze: ");
                keuze = Console.ReadLine();

                if (keuze == "1" || keuze == "2" || keuze == "3" || keuze == "4")
                {
                    Console.Clear();
                    Console.Write("Geef het eerste getal: ");
                    double getal1 = double.Parse(Console.ReadLine());

                    Console.Write("Geef het tweede getal: ");
                    double getal2 = double.Parse(Console.ReadLine());

                    if (keuze == "1")
                    {
                        double som = getal1 + getal2;
                        Console.WriteLine("De som is " + som);
                    }
                    else if (keuze == "2")
                    {
                        double verschil = getal1 - getal2;
                        Console.WriteLine("Het verschil is " + verschil);
                    }
                    
                    else if (keuze == "3")
                    {
                        double product = getal1 * getal2;
                        Console.WriteLine("Het product is " + product);
                    }
                    else
                    {
                        double quotient = getal1 / getal2;
                        Console.WriteLine("Het quotiënt is " + quotient);
                    }

                    Console.WriteLine("\nDruk enter om door te gaan.");
                    Console.ReadLine();
                }
            }
        }
    }
}
