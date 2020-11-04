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
            dgPoissons.ItemsSource = GetListCodeEspecePoisson();
        }

        public List<ViewModelCodeEspecePoisson> GetListCodeEspecePoisson()
        {
            APIAccess api = new APIAccess();
            List<CodeEspecePoissonDTO> listPoisson = api.GetCodeEspecePoissonDTO();
            List<ViewModelCodeEspecePoisson> ls = new List<ViewModelCodeEspecePoisson>();

            foreach (var item in listPoisson)
            {
                ls.Add(new ViewModelCodeEspecePoisson(item.Code_Taxon, item.Code, item.Nom_Commun, item.Nom_Latin, item.Uri_Taxon, item.Statut));
            }
            return ls;
        }

        public ViewModelCodeEspecePoisson GetCodeEspecePoisson(int codeTaxon)
        {
            APIAccess api = new APIAccess();
            var listPoisson = api.GetCodeEspecePoissonDTO(codeTaxon);
            return (new ViewModelCodeEspecePoisson(listPoisson.Code_Taxon, listPoisson.Code, listPoisson.Nom_Commun, listPoisson.Nom_Latin, listPoisson.Uri_Taxon, listPoisson.Statut));
        }
    }
}
