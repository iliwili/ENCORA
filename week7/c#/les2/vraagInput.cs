using System;
using System.Collections.Generic;
using System.Text;

namespace les2
{
    class vraagInput
    {
        static void Main(string[] args)
        {
            // OEFENING 1
            float input = VraagInput();
            Console.Write("Bedankt!");
        }

        static float VraagInput()
        {
            bool success = false;
            float result = 0;

            while (!success)
            {
                Console.Write("Geef een getal in: ");
                string input = Console.ReadLine();

                success = float.TryParse(input, out result);

                if (!success)
                {
                    Console.Write("Foutive invoer. ");
                }
            }

            return result;
        }
    }
}
