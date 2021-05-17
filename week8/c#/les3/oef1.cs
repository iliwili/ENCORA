using System;
using System.Collections.Generic;
using System.Text;

namespace les3
{
    class oef1
    {
        static void Main(string[] args)
        {
            float[] prijzen = { 50, 20.5F, 7, 49.99F, 14 };
            for (int i = 0; i < prijzen.Length; i++)
            {
                if (prijzen[i] < 20)
                {
                    Console.WriteLine($"prijs nummer {i} is {prijzen[i]}");

                }
            }
        }
    }
}
