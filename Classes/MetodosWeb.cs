using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Notfy_LinqToSql.Classes
{
    public class MetodosWeb
    {
        public static void Serializar(HttpContext context, object objeto)
        {
            context.Response.Write(JsonConvert.SerializeObject(objeto));
        }

        public static void Serializar(Func<object> func)
        {
            var context = HttpContext.Current;

            try
            {
                object resultado = func();
                Serializar(context, resultado);
            }
            catch (Exception ex)
            {
                Serializar(context, new { sucesso = false, msgRp = ex.Message });
            }
        }

        public static InfoCep PesquisarCepOnline(string cep)
        {

            if (cep != null)
            {
                cep = Regex.Replace(cep, "[/()-. ]", "", RegexOptions.IgnoreCase);
            }

            try
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var request = new HttpRequestMessage(HttpMethod.Get, string.Format("https://viacep.com.br/ws/{0}/json/", cep)))
                    {
                        using (var response = httpClient.SendAsync(request).Result)
                        {
                            var resultContent = response.Content.ReadAsStringAsync().Result;

                            if (response.IsSuccessStatusCode)
                            {
                                return JsonConvert.DeserializeObject<InfoCep>(resultContent);
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                    }

                }
            }

            catch (Exception)
            {
                throw;
            }
        }

    }

    public class InfoCep
    {
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string erro { get; set; }
    }
}