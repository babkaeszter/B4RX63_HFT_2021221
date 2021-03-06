using B4RX63_HFT_2021221.WpfClient.Pages;
using B4RX63_HFT_2021221.WpfClient.Pages.CoursePage;
using B4RX63_HFT_2021221.WpfClient.Pages.DogPage;
using B4RX63_HFT_2021221.WpfClient.Pages.OwnerPage;
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
            dw.Show();
            this.Close();
        }

        private void Owner_Click(object sender, RoutedEventArgs e)
        {
            OwnerWindow ow = new OwnerWindow();
            ow.Show();
            this.Close();
        }

        private void Course_Click(object sender, RoutedEventArgs e)
        {
            CourseWindow cw = new CourseWindow();
            cw.Show();
            this.Close();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
