using System;

namespace les9
{
    class Program
    {
        // Boek klasse uittesten
        static void Main(string[] args)
        {
            Boek boek = new Boek();

            // antwoord hier is: klaveren 2
            Console.WriteLine($"Eerste kaart: {boek.TrekEersteKaart()}");
            // boek kaarten schudden
            Console.WriteLine("Schudden");
            boek.SchudBoek();
            // antwoord hier zou een andere kaart moeten zijn
            Console.WriteLine($"Eerste kaart: {boek.TrekEersteKaart()}");

            Console.WriteLine($"\nWillekeurige kaart: {boek.TrekEenKaart()}");
        }
    }
}
