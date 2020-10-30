using Controller;
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

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ControllerCodeEspecePoisson listpoissons = new ControllerCodeEspecePoisson();
            dgPoissons.ItemsSource = listpoissons.GetListCodeEspecePoisson();
        }

        private void Button_Click_Get1(object sender, RoutedEventArgs e)
        {
            ViewModelCodeEspecePoisson viewModel = dgPoissons.SelectedItem as ViewModelCodeEspecePoisson;
            WindowGet1 newwin = new WindowGet1(viewModel);
            newwin.Show();
        }


        private void Button_Click_Post(object sender, RoutedEventArgs e)
        {
            //CodeEspecePoissonWindow newwin = new CodeEspecePoissonWindow();
            //newwin.Show();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            //CodeEspecePoissonWindow newwin = new CodeEspecePoissonWindow();
            //newwin.Show();
        }
    }
}
