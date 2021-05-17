using System;
using System.Collections.Generic;
using System.Text;

namespace les9
{
    class Boek
    {
        public List<Kaart> kaarten { get; private set; }

        public Boek()
        {
            kaarten = new List<Kaart> { };
            string[] Kleuren = { "klaveren", "schoppen", "ruiten", "harten" };
            string[] Rangen = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "aas", "boer", "dame", "heer" };

            foreach (var k in Kleuren)
            {
                foreach (var r in Rangen)
                {
                    kaarten.Add(new Kaart { Kleur = k, Rang = r });
                }
            }
        }

        public Kaart TrekEersteKaart()
        {
            return kaarten[0];
        }

        public Kaart TrekEnVerwijderEersteKaart()
        {
            // eerste kaart ophalen
            Kaart eersteKaart = TrekEersteKaart();

            // die kaart dan verwijderen uit de lijst
            kaarten.Remove(eersteKaart);

            // eerste kaart returnen
            return eersteKaart;
        }

        public Kaart TrekEenKaart()
        {
            Random random = new Random();
            int n = random.Next(0, kaarten.Count);

            return kaarten[n];
        }

        public void SchudBoek()
        {
            var random = new Random();
            int n = kaarten.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Kaart kaart = kaarten[k];
                kaarten[k] = kaarten[n];
                kaarten[n] = kaart;
            }
        }
    }
}
