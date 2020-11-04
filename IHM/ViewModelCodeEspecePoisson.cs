using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHM
{
    public class ViewModelCodeEspecePoisson
    {
        public string Code { get; private set; }
        public string Nom_Commun { get; private set; }
        public string Nom_Latin { get; private set; }
        public int Code_Taxon { get; private set; }
        public string Uri_Taxon { get; private set; }
        public string Statut { get; private set; }
        public ViewModelCodeEspecePoisson(int codeTaxon, string code, string nomCommun, string nomLatin, string uriTaxon, string statut)
        {
            Code_Taxon = codeTaxon;
            Code = code;
            Nom_Commun = nomCommun;
            Nom_Latin = nomLatin;
            Uri_Taxon = uriTaxon;
            Statut = statut;
        }
        //public override string ToString()
        //{
        //    return "Code : " + this.Code + ", nom commun : " + this.Nom_Commun + ", nom Latin : " + this.Nom_Latin + ", code Taxon : " + this.Code_Taxon + ", Uri Taxon : " + this.Uri_Taxon + ", statut : " + this.Statut;
        //}
    }
}
