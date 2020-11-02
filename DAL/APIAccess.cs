using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Model;
using System;
using System.Net.Http.Headers;

namespace DAL
{
    public class APIAccess
    {
        #region GET
        private HttpResponseMessage GETO(string URL)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64226/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var result = client.GetAsync(URL);
                result.Wait();

                return result.Result;
            }
        }

        private string GetURI()
        {
            return "api/CodeEspecePoisson";
        }

        public List<CodeEspecePoissonDTO> GetCodeEspecePoissonDTO()
        {
            HttpResponseMessage reponse = GETO(GetURI());
            string content = reponse.Content.ReadAsStringAsync().Result;

            /*Récupérer que la partie "data" qu'on s'intéresse
            var parsedObject = JObject.Parse(content);
            var dataJson = parsedObject["data"].ToString();*/

            List<CodeEspecePoissonDTO> listData = new List<CodeEspecePoissonDTO>();
            if (reponse.StatusCode == System.Net.HttpStatusCode.OK || reponse.StatusCode == System.Net.HttpStatusCode.PartialContent)
            {
                listData = JsonConvert.DeserializeObject<List<CodeEspecePoissonDTO>>(content);
            }
            else
            {
                listData = null;
            }
            return listData;
        }

        public CodeEspecePoissonDTO GetCodeEspecePoissonDTO(int codeTaxon)
        {
            HttpResponseMessage reponse = GETO(GetURI() + "/" + codeTaxon);
            string content = reponse.Content.ReadAsStringAsync().Result;

            //Récupérer que la partie "data" qu'on s'intéresse
            //var parsedObject = JObject.Parse(content);
            //var dataJson = parsedObject["data"].ToString();

            CodeEspecePoissonDTO poisson = new CodeEspecePoissonDTO();
            if (reponse.StatusCode == System.Net.HttpStatusCode.OK || reponse.StatusCode == System.Net.HttpStatusCode.PartialContent)
            {
                poisson = JsonConvert.DeserializeObject<CodeEspecePoissonDTO>(content);
            }
            else
            {
                poisson = null;
            }
            return poisson;
        }
        #endregion

       
    }
}
