using System;

namespace les11
{
    class Vraag
    {
        public string vraagTekst;
        public string[] antwoorden;
        public int correct;
        public string uitleg;

        public Vraag(string vraagTekst, string[] antwoorden, int correct, string uitleg)
        {
            this.vraagTekst = vraagTekst;
            this.antwoorden = antwoorden;
            this.correct = correct;
            this.uitleg = uitleg;
        }
    } 
}