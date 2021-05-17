using System;
using System.Collections.Generic;
using System.Text;

namespace les8
{
    class Auto
    {
        public string Merk;
        public string Model;
        public int Bouwjaar;
        public int NDeuren;
        public string Type;
        public Auto(string merk, string model, int bouwjaar, int nDeuren,
        string type)
        {
            this.Merk = merk;
            this.Model = model;
            this.Bouwjaar = bouwjaar;
            this.NDeuren = nDeuren;
            this.Type = type;
        }
        public void PrintAuto()
        {
            Console.WriteLine($"{Merk} {Model}, {NDeuren}-deurs" +
            $"{Type}, bouwjaar {Bouwjaar}.");
        }

    }
}
