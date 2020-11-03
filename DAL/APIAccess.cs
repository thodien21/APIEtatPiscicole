using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Model;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DAL
{
    public class APIAccess
    {
        #region GET
        private HttpResponseMessage GET(string URL)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64226/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> result = client.GetAsync(URL);
                result.Wait();

                return result.Result;
            }
        }

        public HttpResponseMessage Methode(string URL, string methode, Object body)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64226/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                Task<HttpResponseMessage> result;
                switch(methode.ToUpper())
                {
                    case "GET":
                        result = client.GetAsync(URL);
                        result.Wait();
                        return result.Result;
                    case "PUT":
                        //string json = JsonConvert.SerializeObject(body, Formatting.Indented);
                        //StringContent stringContent = new StringContent(json);
                        //result = client.PutAsync(URL, stringContent);
                        result = client.GetAsync(URL);
                        result.Wait();
                        return result.Result;
                    case "POST":
                        //string json = JsonConvert.SerializeObject(body, Formatting.Indented);
                        //StringContent stringContent = new StringContent(json);
                        //result = client.PostAsync(URL, stringContent);
                        result = client.PostAsJsonAsync(URL, body);
                        result.Wait();
                        return result.Result;
                    default:
                        result = null;
                        result.Wait();
                        return result.Result;
                }
            }
        }

        private string GetUri()
        {
            return "api/CodeEspecePoisson";
        }

        public List<CodeEspecePoissonDTO> GetCodeEspecePoissonDTO()
        {
            //HttpResponseMessage reponse = GET(GetUri());
            var reponse = Methode(GetUri(), "get", null);
            HttpContent contentHttp = reponse.Content;
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
            HttpResponseMessage reponse = GET(GetUri() + "/" + codeTaxon);
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
