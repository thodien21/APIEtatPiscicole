using DAL;
using System;
using System.Windows;

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour WindowGet1.xaml
    /// </summary>
    public partial class WindowGet1 : Window
    {
        public WindowGet1(ViewModelCodeEspecePoisson viewModel)
        {
            InitializeComponent();
            tblCode.Text = viewModel.Code;
            tblNomCommun.Text = viewModel.Nom_Commun;
            tblNomLatin.Text = viewModel.Nom_Latin;
            tblCodeTaxon.Text = viewModel.Code_Taxon.ToString();
            tblUriTaxon.Text = viewModel.Uri_Taxon;
            tblStatut.Text = viewModel.Statut;
        }

        private void Button_Click_Put(object sender, RoutedEventArgs e)
        {
            ViewModelCodeEspecePoisson mybody = GetNewPoisson();
            int id = mybody.Code_Taxon;
            APIAccess myAPI = new APIAccess();
            myAPI.Methode("api/CodeEspecePoisson/" + id, "put", mybody);
        }

        public ViewModelCodeEspecePoisson GetNewPoisson()
        {
            ViewModelCodeEspecePoisson newViewModel = new ViewModelCodeEspecePoisson(Convert.ToInt32(tblCodeTaxon.Text), tblCode.Text, tblNomCommun.Text, tblNomLatin.Text, tblUriTaxon.Text, tblStatut.Text);
            return newViewModel;
        }

        private void Button_Click_Post(object sender, RoutedEventArgs e)
        {
            ViewModelCodeEspecePoisson mybody = GetNewPoisson();
            APIAccess myAPI = new APIAccess();
            myAPI.Methode("api/CodeEspecePoisson", "post", mybody);
        }
    }
}
