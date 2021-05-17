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

namespace les3
{
    /// <summary>
    /// Interaction logic for BekendeTrios.xaml
    /// </summary>
    public partial class BekendeTrios : Window
    {
        public BekendeTrios()
        {
            InitializeComponent();
        }

        private void ClickHarryPotter(object sender, RoutedEventArgs e)
        {
            textBlock1.Text = "Harry";
            textBlock2.Text = "Hermione";
            textBlock3.Text = "Ron";
        }

        private void ClickStarwars(object sender, RoutedEventArgs e)
        {
            textBlock1.Text = "Luke";
            textBlock2.Text = "Leia";
            textBlock3.Text = "Han";
        }

        private void ClickDucktales(object sender, RoutedEventArgs e)
        {
            textBlock1.Text = "Kwik";
            textBlock2.Text = "Kwek";
            textBlock3.Text = "Kwak";
        }
    }
}
