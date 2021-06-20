using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace EcoSistemas.Controllers
{
    public class Token
    {
        public string mensagem { get; set; }
        public string proximaEtapa { get; set; }
        public int statusCode { get; set; }
        public string data { get; set; }
    }

    public class ApiController : Controller
    {

        //URL Base da API  
        public string url = Config.appsettings.GetValue<string>("UrlApi");

        //Buscando o Token para Autenticação 
        public string GetToken()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer");

                var response = client.GetAsync(url + "api/Desafio/GetToken").Result;
                return response.Content.ReadAsStringAsync().Result;
            }

        }

    }
}
