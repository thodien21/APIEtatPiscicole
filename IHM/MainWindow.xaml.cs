using DAL;
using Model;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Windows;

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
            CodeEspecePoissonDTO viewModel = dgPoissons.SelectedItem as CodeEspecePoissonDTO;
            WindowGet1 newwin = new WindowGet1(viewModel);
            newwin.Show();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            CodeEspecePoissonDTO viewModel = dgPoissons.SelectedItem as CodeEspecePoissonDTO;
            int id = viewModel.Code_Taxon;
            APIAccess apiAccess = new APIAccess();
            HttpResponseMessage mess = apiAccess.Methode("api/CodeEspecePoisson/" + id, "delete", null);
            if(mess.IsSuccessStatusCode)
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
            APIAccess api = new APIAccess();
            dgPoissons.ItemsSource = api.GetCodeEspecePoissonDTO();
        }
    }
}
