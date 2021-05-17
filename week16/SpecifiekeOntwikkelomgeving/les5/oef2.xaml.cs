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

namespace les5
{
    /// <summary>
    /// Interaction logic for oef2.xaml
    /// </summary>
    public partial class oef2 : Window
    {
        private List<Auto> Autos = new List<Auto>
        {
            new Auto("Volvo", "66", 1975),
            new Auto("Fiat", "Panda", 1981),
            new Auto("BMW", "732i", 1979),
        };

        public oef2()
        {
            InitializeComponent();

            foreach (var m in Autos)
            {
                listBox.Items.Add(m);
            }

        }

        private void select_Changed(object sender, RoutedEventArgs e)
        {
            Auto auto = (Auto) listBox.SelectedItem;

            textMerk.Text = auto.Merk;
            textModel.Text = auto.Model;
            textJaar.Text = auto.Bouwjaar.ToString();
        }
    }
}
