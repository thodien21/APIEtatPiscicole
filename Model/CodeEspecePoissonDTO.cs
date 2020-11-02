using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Model
{
    public class CodeEspecePoissonDTO
    {
        public int Code_Taxon { get; set; }
        public string Code { get; set; }
        public string Nom_Commun { get; set; }
        public string Nom_Latin { get; set; }
        public string Uri_Taxon { get; set; }
        public string Statut { get; set; }
    }
}
