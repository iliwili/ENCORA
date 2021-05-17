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

namespace les3
{
    /// <summary>
    /// Interaction logic for CelsiusFarenheit.xaml
    /// </summary>
    public partial class CelsiusFarenheit : Window
    {
        private int tempCel = 20;
        public CelsiusFarenheit()
        {
            InitializeComponent();
            updateFields();
        }

        private void minusOne(object sender, RoutedEventArgs e)
        {
            tempCel++;
            updateFields();
        }

        private void plusOne(object sender, RoutedEventArgs e)
        {
            tempCel--;
            updateFields();
        }

        private void updateFields()
        {
            textCelsius.Text = tempCel.ToString() + "C";
            textFarenHeit.Text = celsiusToFarenHeit(tempCel).ToString() + "F";
        }

        private double celsiusToFarenHeit(int celsius)
        {
            return (celsius * 1.8) + 32;
        }
    }
}
