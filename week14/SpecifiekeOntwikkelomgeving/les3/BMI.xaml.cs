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
    /// Interaction logic for BMI.xaml
    /// </summary>
    public partial class BMI : Window
    {
        private int gewicht = 80;
        private int lengte = 180;

        public BMI()
        {
            InitializeComponent();
            updateFields();
        }

        private double calculateBMI()
        {
            double len = (double) lengte / 100;
            return gewicht / (len * len);
        }

        private void updateFields()
        {
            textBMI.Text = "BMI: " + calculateBMI().ToString("0.0");
            textGewicht.Text = gewicht + "KG";
            textLengte.Text = lengte + "CM";
        }

        private void gewichtPlusOne(object sender, RoutedEventArgs e)
        {
            gewicht++;
            updateFields();
        }

        private void gewichtMinusOne(object sender, RoutedEventArgs e)
        {
            gewicht--;
            updateFields();
        }

        private void lengtePlusOne(object sender, RoutedEventArgs e)
        {
            lengte++;
            updateFields();
        }

        private void lengteMinusOne(object sender, RoutedEventArgs e)
        {
            lengte--;
            updateFields();
        }
    }
}
