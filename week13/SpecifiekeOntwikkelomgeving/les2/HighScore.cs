using System;

namespace les2
{
    public class HighScore
    {
        public String Name { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }

        public HighScore(String name, int score, DateTime date)
        {
            Name = name;
            Score = score;
            Date = date;
        }


    }
}
