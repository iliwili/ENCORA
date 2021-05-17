using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace les2
{
    class Program
    {
        static public List<HighScore> HighScores;
        static void Main(string[] args)
        {
            HighScores = new List<HighScore>() { };

            String input = "";

            while (input != "q")
            {
                Console.Clear();

                InitialiseHighscores();
                
                Console.WriteLine("Highscores Manager");
                Console.WriteLine("==================");

                foreach (var h in HighScores)
                {
                    Console.WriteLine($"{h.Name} - {h.Score} - {h.Date}");
                }

                Console.Write("\nEnter gamer name (q to quit): ");
                input = Console.ReadLine();

                if (input == "q")
                {
                    continue;
                }

                Console.Write("Enter highscore: ");
                string score = Console.ReadLine();
                int nScore;
                while (!int.TryParse(score, out nScore))
                {
                    Console.Write("Enter a valid number: ");
                    score = Console.ReadLine();
                }

                HighScores.Add(new HighScore(input, nScore, DateTime.Now));

                HighScores.Sort(delegate (HighScore x, HighScore y) {
                    return y.Score.CompareTo(x.Score);
                });

                List<string> lines = new List<string>() { };
                foreach (var k in HighScores.Count < 10 ? HighScores : HighScores.GetRange(0, 10))
                {
                    lines.Add(ToCSVLine(k));
                }
                File.WriteAllLines("highscores.csv", lines);

                Console.WriteLine("Highscore added.");
                Console.ReadLine();
            }
        }

        static void InitialiseHighscores()
        {
            List<string> lines = File.ReadAllLines("highscores.csv").ToList();

            HighScores.Clear();
            foreach (var l in lines)
            {
                string[] parts = l.Split(";");
                HighScores.Add(new HighScore(parts[0], int.Parse(parts[1]), DateTime.Parse(parts[2])));
            }
        }

        static string ToCSVLine(HighScore h)
        {
            return $"{h.Name};{h.Score};{h.Date}";
        }

    }
}
