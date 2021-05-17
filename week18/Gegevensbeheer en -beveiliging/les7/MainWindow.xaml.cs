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

namespace les7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var db = new warehouseContext())
            {
                var pcs = db.Pieces.ToList();
                foreach (var p in pcs)
                {
                    lbPieces.Items.Add(p);
                }
            }

            StackPanel panelRow = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Name = "sPanel"
            };
            
            spanelProviders.Children.Add(panelRow);

            CheckBox cbox = new CheckBox
            {
                Name = "cProvide"
            };
            panelRow.Children.Add(cbox);

            TextBlock tbox = new TextBlock()
            {
                Name = "tProvide",
                Width = 50
            };
            panelRow.Children.Add(tbox);


            CheckBox test = spanelProviders.FindName("cProvide") as CheckBox;
            Console.WriteLine(test.Name);
            lbPieces.SelectedIndex = 0;
        }

        public void SelectPiece(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine(spanelProviders.FindName("sPanel"));
            //StackPanel rowPanel = spanelProviders.FindName("sPanel") as StackPanel;
            ClearChildren((StackPanel) spanelProviders.Children[1]);

            var piece = (Pieces) lbPieces.SelectedItem;

            using (var db = new warehouseContext())
            {
                var pObject = db.Provides.Where(p => p.Piece == piece.Code);
                var provide = pObject.First<Provides>();
                
                CheckBox cbox = spanelProviders.FindName("cProvide") as CheckBox;
                TextBlock tbox = spanelProviders.FindName("tProvide") as TextBlock;

                if (provide != null)
                {
                    cbox.IsChecked = true;
                    tbox.Text = provide.Price.ToString();
                }
                else
                {
                    cbox.IsChecked = false;
                    tbox.Text = "0";
                }

            }

            Console.WriteLine(piece.Name);
            
        }

        public void ClearChildren(StackPanel stackP)
        {
            foreach (StackPanel row in stackP.Children)
            {
                row.Children.OfType<CheckBox>().FirstOrDefault().IsChecked = false;
                row.Children.OfType<TextBlock>().FirstOrDefault().Text = "";
            }
        }
    }
}
