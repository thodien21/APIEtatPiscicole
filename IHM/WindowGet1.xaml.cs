﻿using Controller;
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
using System.Windows.Shapes;

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
            GetNewPoisson();
        }

        public ViewModelCodeEspecePoisson GetNewPoisson()
        {
            ViewModelCodeEspecePoisson newViewModel = new ViewModelCodeEspecePoisson(tblCode.Text, tblNomCommun.Text, tblNomLatin.Text, Convert.ToInt32(tblCodeTaxon.Text), tblUriTaxon.Text, tblStatut.Text);
            return newViewModel;
        }
    }
}