using DAL;
using Model;
using System;
using System.Net;
using System.Net.Http;
using System.Windows;

namespace IHM
{
    /// <summary>
    /// Logique d'interaction pour WindowGet1.xaml
    /// </summary>
    public partial class WindowGet1 : Window
    {
        public WindowGet1(CodeEspecePoissonDTO viewModel)
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
            CodeEspecePoissonDTO mybody = GetNewPoisson();
            int id = mybody.Code_Taxon;
            APIAccess myAPI = new APIAccess();
            HttpResponseMessage mess = myAPI.Methode("api/CodeEspecePoisson/" + id, "put", mybody);
            if(mess.IsSuccessStatusCode)
            {
                MessageBox.Show("Poisson " + mybody.Nom_Commun + " a été bien mis à jour \n Status Code : " + mess.StatusCode);
            }
            else
            {
                MessageBox.Show("La MAJ de " + mybody.Nom_Commun + " a rencontré une erreur : " + mess.StatusCode + " : " + mess.ReasonPhrase);
            }
        }

        private void Button_Click_Post(object sender, RoutedEventArgs e)
        {
            CodeEspecePoissonDTO mybody = GetNewPoisson();
            APIAccess myAPI = new APIAccess();
            HttpResponseMessage mess = myAPI.Methode("api/CodeEspecePoisson", "post", mybody);
            if (mess.IsSuccessStatusCode)
            {
                MessageBox.Show("Poisson " + mybody.Nom_Commun + " a été bien ajouté \n Status Code : " + mess.StatusCode);
            }
            else
            {
                MessageBox.Show("L'ajout de " + mybody.Nom_Commun + " a rencontré une erreur : " + mess.StatusCode + " : " + mess.ReasonPhrase);
            }
        }
        public CodeEspecePoissonDTO GetNewPoisson()
        {
            CodeEspecePoissonDTO newViewModel = new CodeEspecePoissonDTO(Convert.ToInt32(tblCodeTaxon.Text), tblCode.Text, tblNomCommun.Text, tblNomLatin.Text, tblUriTaxon.Text, tblStatut.Text);
            return newViewModel;
        }
    }
}
