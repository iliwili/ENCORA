using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace les5
{
    public class Auto
    {
        public string Merk { get; set; }
        public string Model { get; set; }
        public int Bouwjaar { get; set; }
        public Auto(string merk, string model, int bouwjaar)
        {
            Merk = merk;
            Model = model;
            Bouwjaar = bouwjaar;
        }

        public override string ToString()
        {
            return $"{Merk} - {Model} - {Bouwjaar}";
        }
    }
}
