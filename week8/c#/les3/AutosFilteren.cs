using System;
using System.Collections.Generic;
using System.Text;

namespace les3
{
    class AutosFilteren
    {

        static void Main(string[] args)
        {
            string[] merk = { "Volvo", "Fiat", "BMW", "Volvo", "Volvo", "BMW" };
            string[] model = { "66", "Panda", "732i", "265", "340", "525" };
            int[] bouwjaar = { 1975, 1981, 1979, 1980, 1982, 1974 };
            int[] aantalDeuren = { 2, 3, 3, 5, 5, 4 };
            string[] type = { "sedan", "hatchback", "sedan", "wagon", "hatchback", "sedan" };


            string input = "";

            ToonTitel();
            while (input != "q")
            {
                input = VraagInput();

                if (input == "1")
                {
                    FilterOpMerk(merk, model, bouwjaar, aantalDeuren, type);
                } else if (input == "2")
                {
                    FilterOpJaartal(merk, model, bouwjaar, aantalDeuren, type);
                }
            }
        }

        static void ToonTitel()
        {
            Console.WriteLine("AUTOSHOP\n");
        }

        static string VraagInput()
        {
            Console.WriteLine("\n1. Zoek op het merk");
            Console.WriteLine("2. Zoek op jaartal");
            Console.WriteLine("q. Stop");

            Console.Write("\nJouw keuze: ");
            return Console.ReadLine();
        }

        static void FilterOpMerk(string[] merk, string[] model, int[] bouwjaar, int[] aantalDeuren, string[] type)
        {
            Console.Write("\nGeef het merk: ");
            string zoekMerk = Console.ReadLine();

            Console.Clear();
            ToonTitel();

            Console.WriteLine("Gevonden: ");
            for (int index = 0; index < merk.Length; index++)
            {
                if (merk[index].Equals(zoekMerk))
                {
                    Console.WriteLine(merk[index] + " " + model[index] + ", bouwjaar: " + bouwjaar[index] + ", aantal deuren: " + aantalDeuren[index] + ", type: " + type[index]);
                }
            }
        }

        static void FilterOpJaartal(string[] merk, string[] model, int[] bouwjaar, int[] aantalDeuren, string[] type)
        {
            Console.Write("Geef het minimum jaar: ");
            int min = int.Parse(Console.ReadLine());
            Console.Write("Geef het maximum jaar: ");
            int max = int.Parse(Console.ReadLine());

            Console.Clear();
            ToonTitel();

            Console.WriteLine("Gevonden: ");
            for (int index = 0; index < bouwjaar.Length; index++)
            {
                if (bouwjaar[index] >= min && bouwjaar[index] <= max)
                {
                    Console.WriteLine(merk[index] + " " + model[index] + ", bouwjaar: " + bouwjaar[index] + ", aantal deuren: " + aantalDeuren[index] + ", type: " + type[index]);
                }
            }
        }
    }
}
