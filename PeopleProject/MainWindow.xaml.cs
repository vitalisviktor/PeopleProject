using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PeopleProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        People p;
        public MainWindow()
        {
            InitializeComponent();
            p = new People();
            lbx_people.ItemsSource = p.Eletkorok;
        }

        private void btn_addnew_Click(object sender, RoutedEventArgs e)
        {
            p.UjSzemely(Convert.ToInt32(txbx_newage.Text));
            lbx_people.Items.Refresh();
            ImgUpdate();
        }

        private void btn_average_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Convert.ToString(p.AtlagEletkor(Convert.ToInt32(txbx_min.Text), Convert.ToInt32(txbx_max.Text))), "Átlag Érték", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ImgUpdate()
        {
            
            switch (p.KategoriaAtlagOsszesbol())
            {
                
                case "Gyerek":
                    img_age.Source = new BitmapImage(new Uri("/gyerek.jpg", UriKind.Relative));
                    break;
                case "Felnőtt":
                    img_age.Source = new BitmapImage(new Uri("/felnott.jpg", UriKind.Relative));
                    break;
                case "Nyugdíjas":
                    img_age.Source = new BitmapImage(new Uri("/nyugdijas.jpg", UriKind.Relative));
                    break;
            }
        }
    }
}