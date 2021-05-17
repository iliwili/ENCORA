using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace les6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

        static List<Video> Videos = new List<Video>
        {
            new Movie("Jaws", 124, "Steven Spielberg", 1975, "Thriller", 3),
            new Movie("The Lobster", 119, "Yorgos Lanthimos", 2015, "Comedy", 4),
            new MusicVideo("Video killed the radio star", 240, "The Buggles", 5)
        };


        public MainWindow()
        {
            InitializeComponent();

            foreach (Video video in Videos)
            {
                listBoxVideos.Items.Add(video);
            }
        }

        private void DeleteVideo(object sender, RoutedEventArgs e)
        {
            Video selectedVideo = (Video) listBoxVideos.SelectedItem;

            if (selectedVideo != null)
            {
                Videos.Remove(selectedVideo);
                listBoxVideos.Items.Remove(selectedVideo);
            }
        }

        private void SelectVideo(object sender, RoutedEventArgs e)
        {
            Video selectedVideo = (Video) listBoxVideos.SelectedItem;

            tabs.SelectedIndex = selectedVideo is Movie ? 0 : 1;

            if (selectedVideo is Movie)
            {
                Movie movie = (Movie) selectedVideo;
                tabs.SelectedIndex = 0;
            }
            else
            {
                MusicVideo musicVideo= (MusicVideo) selectedVideo;
                tabs.SelectedIndex = 1;

                textMVTitle.Text = musicVideo.Title;
                textMVArtist.Text = musicVideo.Artist;
                textMVLength.Text = musicVideo.Length.ToString();
                textMVRating.Text = musicVideo.Rating.ToString();
            }
        }

        private void addMusicVideo(object sender, RoutedEventArgs e)
        {
            MusicVideo newMusicVideo = new MusicVideo(textMVTitle.Text, int.Parse(textMVLength.Text), textMVArtist.Text,
                int.Parse(textMVRating.Text));

            Debug.Write(Videos.IndexOf(newMusicVideo));

            int index = Videos.IndexOf(newMusicVideo);
            
            if (index < 0)
            {
                Videos.Add(newMusicVideo);
                listBoxVideos.Items.Add(newMusicVideo);
            }
            else
            {
                MessageBox.Show("Music video already exists!");
            }
        }
    }
}
