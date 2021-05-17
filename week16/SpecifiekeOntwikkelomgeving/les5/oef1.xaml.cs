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
    /// Interaction logic for oef1.xaml
    /// </summary>
    public partial class oef1 : Window
    {
        public oef1()
        {
            InitializeComponent();
        }

        private void selection_Changed(object sender, RoutedEventArgs e)
        {
            //var lbItem = (ListBoxItem)mijnListBox.SelectedItem;
            //MessageBox.Show(lbItem.Content.ToString());
        }

        private void double_Click(object sender, RoutedEventArgs e)
        {
            var lbItem = (ListBoxItem)mijnListBox.SelectedItem;
            if (lbItem != null)
                MessageBox.Show(lbItem.Content.ToString());
        }
    }
}
