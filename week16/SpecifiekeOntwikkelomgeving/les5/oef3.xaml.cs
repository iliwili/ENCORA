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
using System.Windows.Shapes;

namespace les5
{
    /// <summary>
    /// Interaction logic for oef3.xaml
    /// </summary>
    public partial class oef3 : Window
    {
        private List<Movie> Movies { get; set; } = new List<Movie>
        {
            new Movie("The Matrix", 1999, "Sci-Fi", "The Wachowskis", 136),
            new Movie("The Big Lebowski", 1998, "Comedy", "Joel Coen", 117),
            new Movie("Inception", 2010, "Sci-Fi", "Christopher Nolan", 148),
            new Movie("Catch me if you can", 2002, "Crime", "Steven Spielberg", 141),
        };

        public oef3()
        {
            InitializeComponent();

            Movies.ForEach(movie => movieListBox.Items.Add(movie));
        }

        private void SelectMovie(object sender, RoutedEventArgs e)
        {

        }

        private void AddMovie(object sender, RoutedEventArgs e)
        {
            if (!textNaam.Text.Equals("") && !textRelease.Text.Equals("") && !textGenre.Text.Equals("") &&
                !textRegisseur.Text.Equals("") && !textSpeelduur.Text.Equals(""))
            {
                Movie newMovie = new Movie(textNaam.Text, int.Parse(textRelease.Text), textGenre.Text,
                    textRegisseur.Text, int.Parse(textSpeelduur.Text));

                int index = Movies.IndexOf(newMovie);

                if (index < 0)
                {
                    movieListBox.Items.Add(newMovie);
                }
                else
                {
                    MessageBox.Show("Movie does already exist.");
                }

            }
        }

        private void DeleteMovie(object sender, RoutedEventArgs e)
        {
            Movie selectedMovie = (Movie) movieListBox.SelectedItem;

            if (selectedMovie != null)
            {
                Movies.Remove(selectedMovie);
                movieListBox.Items.Remove(selectedMovie);
            }
        }
    }
}
