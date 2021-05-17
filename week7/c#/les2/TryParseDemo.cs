using System;

namespace les2
{
    class TryParseDemo
    {
        static void Main(string[] args)
        {
            Console.Write("Geef een getal in: ");
            string input = Console.ReadLine();

            bool sucess = float.TryParse(input, out float result);

            if (sucess)
            {
                Console.WriteLine("Je gaf een getal in, namelijk " + result);
            } else
            {
                Console.WriteLine("Gelieve een getal in te geven aub.");
            }
        }
    }
}
