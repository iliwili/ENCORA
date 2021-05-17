using System;
using System.Collections.Generic;
using System.Text;

namespace les9
{
    class Kaart
    {
        public string Kleur;
        public string Rang;

        public override string ToString()
        {
            return $"{Kleur} {Rang}";
        }

        public int BerekenWaarde()
        {
            int waarde;
            if (this.Rang == "aas" || this.Rang == "boer" || this.Rang == "dame" || this.Rang == "heer")
            {
                waarde = 10;
            } else
            {
                waarde = int.Parse(this.Rang);
            }
            return waarde;
        }
    }
}
