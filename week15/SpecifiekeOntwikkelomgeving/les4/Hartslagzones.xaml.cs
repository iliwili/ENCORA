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
    /// Interaction logic for Hartslagzones.xaml
    /// </summary>
    public partial class Hartslagzones : Window
    {
        private int age = 18;

        public Hartslagzones()
        {
            InitializeComponent();
            textLeeftijd.Text = age.ToString();
        }

        private void Age_Changed(object sender, EventArgs e)
        {
            if (int.TryParse(textLeeftijd.Text, out age))
            {
                Update_Zones();
            }
        }

        private void Update_Zones()
        {
            int max_hartslag = 220 - age;

            textZone5.Text = "Zone 5: " + (max_hartslag * 0.9).ToString("0") + " tot " + max_hartslag + " bpm";
            textZone4.Text = "Zone 4: " + (max_hartslag * 0.8).ToString("0") + " tot " + (max_hartslag * 0.9).ToString("0") + " bpm";
            textZone3.Text = "Zone 3: " + (max_hartslag * 0.7).ToString("0") + " tot " + (max_hartslag * 0.8).ToString("0")+ " bpm";
            textZone2.Text = "Zone 2: " + (max_hartslag * 0.6).ToString("0") + " tot " + (max_hartslag * 0.7).ToString("0") + " bpm";
            textZone1.Text = "Zone 1: " + (max_hartslag * 0.5).ToString("0") + " tot " + (max_hartslag * 0.6).ToString("0") + " bpm";
        }
    }
}
