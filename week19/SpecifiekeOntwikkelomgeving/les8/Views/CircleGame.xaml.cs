using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace les8.Views
{
    /// <summary>
    /// Interaction logic for CircleGame.xaml
    /// </summary>
    public partial class CircleGame : Window
    {
        // PROPERTIES FOR HIGHSCORES
        public string UserName { get; set; }
        public int Score { get; set; }
        public float Accuracy { get; set; }

        // PROPERTIES FOR THE GAME
        public List<Ball> Circles { get; set; }
        public int Timer { get; set; }
        public int CountClicks { get; set; }

        SoundPlayer HitSound = new SoundPlayer(Properties.Resources.hit_sound);
        SoundPlayer MissSound = new SoundPlayer(Properties.Resources.mis_sound);
        private SoundPlayer EndGameSound = new SoundPlayer(Properties.Resources.end_game);

        // HELPER PROPERTIES
        private readonly Random Random = new Random();
        
        private bool isWindowOpen = false;

        private DispatcherTimer dt = new DispatcherTimer();

        public CircleGame()
        {
            InitializeComponent();

            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += Timer_Tick;
        }

        public void ClickEvent_StartGame(object sender, RoutedEventArgs e)
        {
            UserName = txtUsername.Text;

            if (UserName.Equals(""))
            {
                MessageBox.Show("Username is required!");
                return;
            }

            ResetGame();
        }

        public void ClickEvent_GoBack(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }

        public void ClickEvent_CheckHighScores(object sender, RoutedEventArgs e)
        {
            HighScores highScores = new HighScores();
            if (!isWindowOpen)
            {
                highScores.Show();
                isWindowOpen = true;
            }

            highScores.Closed += new EventHandler((object send, EventArgs ev) =>
            {
                isWindowOpen = false;
            });
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            Timer--;

            lblTimer.Content = 0 + ":" + Timer;
        }

        public void ResetGame()
        {
            Timer = 20;
            Score = 0;
            Accuracy = 0;
            CountClicks = 0;

            InitializeCircles();


            foreach (var circle in Circles)
            {
                circle.AddToCanvas(cnvs);
            }

            dt.Start();

            lblEndGame.Visibility = Visibility.Hidden;
            lblEndScore.Visibility = Visibility.Hidden;
            bGoBack.Visibility = Visibility.Hidden;
            bStartGame.Visibility = Visibility.Hidden;
            txtUsername.Visibility = Visibility.Hidden;
            bCheckHighScores.Visibility = Visibility.Hidden;

            CompositionTarget.Rendering += Loop;
        }

        public void EndGame()
        {
            dt.Stop();
            EndGameSound.Play();

            foreach (var circle in Circles)
            {
                cnvs.Children.Remove(circle.Ellps);
            }

            Circles.Clear();

            lblEndScore.Content = $"Score: {Score}, Accuracy: {Math.Round(Accuracy)}%";

            lblEndGame.Visibility = Visibility.Visible;
            lblEndScore.Visibility = Visibility.Visible;
            bGoBack.Visibility = Visibility.Visible;

            bStartGame.Content = "Restart Game";
            bStartGame.Visibility = Visibility.Visible;

            CompositionTarget.Rendering -= Loop;

            AddHighScore();
        }

        public void RestartGame()
        {
            bCheckHighScores.Visibility = Visibility.Visible;
            txtUsername.Visibility = Visibility.Visible;
            txtUsername.Text = "";


            bStartGame.Content = "Start Game";

            lblEndGame.Visibility = Visibility.Hidden;
            lblEndScore.Visibility = Visibility.Hidden;
            bGoBack.Visibility = Visibility.Hidden;
        }

        public void InitializeCircles()
        {
            Circles = new List<Ball>();

            for (int i = 0; i < 5; i++)
            {
                Circles.Add(new Ball(Random.Next(60, 800 - 65), Random.Next(35, 450 - 50), 40, 40, Timer, false));
            }
        }

        public void ClickEvent(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Ellipse circle)
            {
                var ball = Circles.Find(b => b.Ellps == circle);

                if (ball.IsEnemy)
                {
                    MissSound.Play();
                    Score--;
                }
                else
                {
                    HitSound.Play();
                    Score++;
                }

                cnvs.Children.Remove(circle);
                AddCircle();
            }

            CountClicks++;
            
            Accuracy = ((float) Score / CountClicks) * 100;
            
            lblAccuracy.Content = $"Accuracy: {Math.Round(Accuracy)}%";
            lblScore.Content = $"Score: {Score}";
        }

        private void Loop(object sender, EventArgs e)
        {
            var removeBalls = Circles.FindAll(b => (b.SpawnTime - Timer) >= 2 && b.IsEnemy);

            if (removeBalls.Count >= 1)
            {
                foreach (var ball in removeBalls)
                {
                    cnvs.Children.Remove(ball.Ellps);
                    Circles.Remove(ball);
                    AddCircle();
                }
            }

            foreach (var circle in Circles)
            {
                circle.Move();
            }

            if (Timer == 0)
            {
                EndGame();
            }
        }

        private void AddCircle()
        {
            var circle = new Ball(Random.Next(60, 800 - 65), Random.Next(35, 450 - 50), 40, 40, Timer, Random.Next(100) < 40);
            
            Circles.Add(circle);
            circle.AddToCanvas(cnvs);
        }
        private void AddHighScore()
        {
            using (var db = new GameContext())
            {
                var highScore = db.HighScore.FirstOrDefault(h => h.Username.Equals(UserName));

                if (highScore != null)
                {
                    if (highScore.Score < Score)
                    {
                        highScore.Score = Score;
                       db.HighScore.Update(highScore);
                    }
                }
                else
                {
                    db.HighScore.Add(new HighScore {Score = Score, Username = UserName});
                }


                db.SaveChanges();
            }
        }
    }
}
