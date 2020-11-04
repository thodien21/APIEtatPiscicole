using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Model
{
    public class CodeEspecePoissonDTO
    {
        public string Code { get; set; }
        public string Nom_Commun { get; set; }
        public string Nom_Latin { get; set; }
        public int Code_Taxon { get; set; }
        public string Uri_Taxon { get; set; }
        public string Statut { get; set; }
        public CodeEspecePoissonDTO()
        {

        }
        public CodeEspecePoissonDTO(int codeTaxon, string code, string nomCommun, string nomLatin, string uriTaxon, string statut)
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
