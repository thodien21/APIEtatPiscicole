using Controller;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            GetAllFish();
        }

        private void Button_Click_Get1(object sender, RoutedEventArgs e)
        {
            ViewModelCodeEspecePoisson viewModel = dgPoissons.SelectedItem as ViewModelCodeEspecePoisson;
            WindowGet1 newwin = new WindowGet1(viewModel);
            newwin.Show();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            ViewModelCodeEspecePoisson viewModel = dgPoissons.SelectedItem as ViewModelCodeEspecePoisson;
            int id = viewModel.Code_Taxon;
            APIAccess apiAccess = new APIAccess();
            HttpResponseMessage mess = apiAccess.Methode("api/CodeEspecePoisson/" + id, "delete", null);
            if(mess.StatusCode == HttpStatusCode.OK )
            {
                MessageBox.Show("Poisson supprimée");
            }
            else
            {
                MessageBox.Show("Suppression rencontre une erreur : ", mess.ReasonPhrase);
            }
        }

        private void Button_Click_Refresh(object sender, RoutedEventArgs e)
        {
            GetAllFish();
        }

        private void GetAllFish()
        {
            ControllerCodeEspecePoisson listpoissons = new ControllerCodeEspecePoisson();
            dgPoissons.ItemsSource = listpoissons.GetListCodeEspecePoisson();
        }
    }
}
