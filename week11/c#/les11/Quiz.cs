using System;
using System.Collections.Generic;

namespace les11
{
    class Quiz
    {
        public List<Vraag> vragen;
        private int huidigeVraag;
        private int aantalCorrectGeantwoord;
        public Boolean isGeeindigd;

        public Quiz()
        {
            vragen = new List<Vraag> {
                new Vraag("Wat is geen saus?", new string[] { "Béarnaise", "Marseillaise", "Ravigotte" }, 2, "Marseillaise; dat is het Franse volkslied"),
                new Vraag("Welke kleuren ontstaan als je je vreselijk ergert?", new string[] { "Rood en geel", "Groen en grijs", "Groen en geel" }, 3, "Groen en geel"),
                new Vraag("Waarom staan flamingo’s vaak op één been?", new string[] { "Om niet af te koelen", "Tegen bijtende visjes", "Om het andere been te sparen"}, 1, "Om niet af te koelen; minder poot in het water betekent minder warmteverlies"),
                new Vraag("Bij welke sport wordt soms heel hard geroepen: One hundred and eighty!", new string[] { "Darten", "Kogelstoten ", "Klassiek ballet" }, 1, "Darten"),
                new Vraag("Welk fruit is vernoemd naar een vogel?", new string[] { "Durian", "Kiwi ", "Pink Lady" }, 2, "De kiwi is vernoemd naar een vogel uit Nieuw-Zeeland")
            };
            huidigeVraag = 0;
            aantalCorrectGeantwoord = 0;
            isGeeindigd = false;
        }

        public string StelVraag()
        {
            Vraag vraag = vragen[huidigeVraag];
            string vraagAntwoord = "";

            vraagAntwoord += $"{vraag.vraagTekst}\n";

            for (int i = 0; i < vraag.antwoorden.Length; i++)
            {
                vraagAntwoord += $"\n{i+1}. {vraag.antwoorden[i]}";
            }

            vraagAntwoord += "\n\n1, 2 of 3? ";

            return vraagAntwoord;
        }

        public string ControleerAntwoord(int antwoord)
        {
            Vraag vraag = vragen[huidigeVraag];

            if (vraag.antwoorden.Length < huidigeVraag) {
                this.isGeeindigd = true;
            }

            if (vraag.correct == antwoord) {
                aantalCorrectGeantwoord++;
                return $"Het antwoord was juist! {vraag.uitleg}";
            }
            return $"Het antwoord was fout!\nHet juist antwoord was {vraag.correct}. {vraag.uitleg}";
        }

        public string Score()
        {
            return $"Jouw score: {this.aantalCorrectGeantwoord}/{this.huidigeVraag+1}";
        }

        public void GaNaarVolgendeVraag()
        {
            huidigeVraag++;
        }
    }
}