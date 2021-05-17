using System;

namespace les11
{
    class Program
    {
        static void Main(string[] args)
        {
            Quiz quiz = new Quiz();

            Console.Clear();
            Console.WriteLine("DE ENCORA QUIZ");
            Console.WriteLine("==============");

            while (!quiz.isGeeindigd)
            {
                Console.Write(quiz.StelVraag());
                string strAntwoord = Console.ReadLine();
                int intAntwoord;

                while(!int.TryParse(strAntwoord, out intAntwoord))
                {
                    Console.Write("Geef een getal in: ");
                    strAntwoord = Console.ReadLine();
                }

                Console.WriteLine(quiz.ControleerAntwoord(intAntwoord));
                Console.WriteLine(quiz.Score());
                quiz.GaNaarVolgendeVraag();
                Console.ReadLine();
            }
            Console.WriteLine("\nEinde van de quiz!");
        }
    }
}
