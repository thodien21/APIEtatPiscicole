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
                        result = client.PutAsJsonAsync(URL, body);
                        result.Wait();
                        var re2s = result.Result.Content.ToString();
                        return result.Result;
                    case "POST":
                        result = client.PostAsJsonAsync(URL, body);
                        result.Wait();
                        var res = result.Result.Content.ToString();
                        return result.Result;
                    case "DELETE":
                        result = client.DeleteAsync(URL);
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
            var reponse = Methode(GetUri(), "get", null);
            HttpContent contentHttp = reponse.Content;
            string content = reponse.Content.ReadAsStringAsync().Result;

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
            HttpResponseMessage reponse = Methode(GetUri() + "/" + codeTaxon, "get", null);
            string content = reponse.Content.ReadAsStringAsync().Result;

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
    }
}
