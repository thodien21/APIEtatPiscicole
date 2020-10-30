using DAL;
using Model;
using System.Collections.Generic;

namespace Controller
{
    public class ControllerCodeEspecePoisson
    {
        public List<ViewModelCodeEspecePoisson> GetListCodeEspecePoisson()
        {
            APIAccess api = new APIAccess();
            List<CodeEspecePoissonDTO> listPoisson = api.GetCodeEspecePoissonDTO();
            List<ViewModelCodeEspecePoisson> ls = new List<ViewModelCodeEspecePoisson>();
            
            foreach (var item in listPoisson)
            {
                ls.Add(new ViewModelCodeEspecePoisson(item.Code, item.Nom_Commun, item.Nom_Latin, item.Code_Taxon, item.Uri_Taxon, item.Statut));
            }
            return ls;
        }

        public ViewModelCodeEspecePoisson GetCodeEspecePoisson(int codeTaxon)
        {
            APIAccess api = new APIAccess();
            var listPoisson = api.GetCodeEspecePoissonDTO(codeTaxon);
            return (new ViewModelCodeEspecePoisson(listPoisson.Code, listPoisson.Nom_Commun, listPoisson.Nom_Latin, listPoisson.Code_Taxon, listPoisson.Uri_Taxon, listPoisson.Statut));
        }

        //public CodeEspecePoissonDTO PutCodeEspecePoisson()
        //{
            
        //}
    }
}
