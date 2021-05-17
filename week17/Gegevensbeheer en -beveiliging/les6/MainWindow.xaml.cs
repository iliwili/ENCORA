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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace les6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static List<Bestelling> Bestellingen { get; set; } = new List<Bestelling> { };
        public static List<Drank> Dranken { get; set; } = new List<Drank> { };

        public MainWindow()
        {
            InitializeComponent();

            using (var db = new CafeContext())
            {
                Bestellingen = db.Bestelling.ToList();
            }
            BestellingenGrid.ItemsSource = Bestellingen;

            
            using (var db = new CafeContext())
            {
                Dranken = db.Drank.ToList();
            }
            DrankenGrid.ItemsSource = Dranken;
            
            foreach (Drank drank in Dranken)
            {
                lbDrank.Items.Add(drank);
            }
        }

        public void add_Bestellingen(object sender, RoutedEventArgs e)
        {
            var selectDrank = (Drank) lbDrank.SelectedItem;

            if (selectDrank == null)
            {
                MessageBox.Show("Kies een drankje!");
            }

            using (var db = new CafeContext())
            {
                var bestelling = new Bestelling() { DrankID = selectDrank.ID};
                db.Bestelling.Add(bestelling);
                Bestellingen.Add(bestelling);
                
                BestellingenGrid.Items.Refresh();
                
                db.SaveChanges();
            }
        }

        public void delete_Bestellingen(object sender, RoutedEventArgs e)
        {
            var selectedBestelling = (Bestelling)BestellingenGrid.SelectedItem;

            using (var db = new CafeContext())
            {
                db.Bestelling.Remove(selectedBestelling);
                Bestellingen.Remove(selectedBestelling);

                BestellingenGrid.Items.Refresh();

                db.SaveChanges();
            }
        }

        // UPDATE
        public void DrankenGrid_Edited(object sender, DataGridCellEditEndingEventArgs e)
        {
            var drank = (Drank) e.Row.Item;
            var element = e.EditingElement as TextBox;
            string merk = element.Text.ToString();

            drank.Merk = merk;

            using (var db = new CafeContext())
            {
                db.Drank.Update(drank);
                db.SaveChanges();
            }
        }

        public void add_Dranken(object sender, RoutedEventArgs e)
        {
            if (dMerk.Text.Equals(""))
            {
                MessageBox.Show("Het merk is niet ingevuld");
                return;
            }

            using (var db = new CafeContext())
            {
                var drank = new Drank() {Merk = dMerk.Text};
                db.Drank.Add(drank);
                Dranken.Add(drank);
                
                DrankenGrid.Items.Refresh();
                dMerk.Text = "";

                db.SaveChanges();
            }
        }

        public void delete_Dranken(object sender, RoutedEventArgs e)
        {
            var selectedDrank = (Drank)DrankenGrid.SelectedItem;

            using (var db = new CafeContext())
            {
                db.Drank.Remove(selectedDrank);
                Dranken.Remove(selectedDrank);

                DrankenGrid.Items.Refresh();

                db.SaveChanges();
            }
        }
    }
}
