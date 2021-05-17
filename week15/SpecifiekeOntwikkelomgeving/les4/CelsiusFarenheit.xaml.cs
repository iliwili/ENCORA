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

namespace les4
{
    /// <summary>
    /// Interaction logic for CelsiusFarenheit.xaml
    /// </summary>
    public partial class CelsiusFarenheit : Window
    {
        public CelsiusFarenheit()
        {
            InitializeComponent();
        }

        private void toCelsius(object sender, RoutedEventArgs e)
        {
            double farenheit = 0;
            if (double.TryParse(textFarenheit.Text, out farenheit))
            {
                MessageBox.Show(((farenheit - 32) / 1.8) + " farenheit");
            }
        }

        private void toFarenheit(object sender, RoutedEventArgs e)
        {
            double celsius = 0;
            if (double.TryParse(textCelsius.Text, out celsius))
            {
                MessageBox.Show(((celsius * 1.8) + 32) + " celsius");
            }
        }
    }
}
