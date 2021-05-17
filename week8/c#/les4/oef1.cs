using System;
using System.Collections.Generic;
using System.Text;

namespace les4
{
    class oef1
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string> {
                "Bergamont Grandurance RD7",
                "Tokyobike Bisou",
                "Koga E-Worldtraveller",
                "Achielle Sam",
                "Santos Travelmaster 2.8"
            };

            string input = "";

            while (input != "q")
            {
                Console.Clear();
                for (int index = 0; index < names.Count; index++)
                {
                    Console.WriteLine(names[index]);
                }

                Console.Write("\nGeef een nieuw fietsmodel in (q om te stoppen): ");
                input = Console.ReadLine();

                if (input.Length > 0 && !input.Equals("q"))
                {
                    names.Add(input);
                }
            }

            
        }
    }
}
