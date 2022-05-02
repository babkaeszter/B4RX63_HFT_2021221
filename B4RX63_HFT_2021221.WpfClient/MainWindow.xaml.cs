using B4RX63_HFT_2021221.WpfClient.Pages;
using B4RX63_HFT_2021221.WpfClient.Pages.DogPage;
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

namespace B4RX63_HFT_2021221.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Dog_Click(object sender, RoutedEventArgs e)
        {
            DogWindow dw = new DogWindow();
            dw.ShowDialog();
            this.Close();
        }

        private void Owner_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Course_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
