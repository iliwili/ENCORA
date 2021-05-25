using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace les8.Views
{
    /// <summary>
    /// Interaction logic for HighScores.xaml
    /// </summary>
    public partial class HighScores : Window
    {
        public static List<HighScore> HighScoreList { get; set; } = new List<HighScore> { };
        public HighScores()
        {
            InitializeComponent();

            using (var db = new GameContext())
            {
                HighScoreList = db.HighScore.ToList();
            }

            HighScoreList.Sort((h1, h2) => h2.Score - h1.Score);


            foreach (HighScore highScore in HighScoreList)
            {
                lbHighScores.Items.Add(highScore);
            }
        }
    }
}
