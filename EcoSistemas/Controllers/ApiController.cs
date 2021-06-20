using EcoSistemas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

    public class Passo
    {
        public string mensagem { get; set; }
        public string proximaEtapa { get; set; }
        public int statusCode { get; set; }
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

        //Busca Pacientes
        public string GetPaciente()
        {
            //Recebendo o token
            string token = GetToken();

            Token tokenDados = System.Text.Json.JsonSerializer.Deserialize<Token>(token);

            using (var client = new HttpClient())
            {
                if (!string.IsNullOrWhiteSpace(token))
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenDados.data);
                }
                var response = client.GetAsync(url + "api/Desafio/GetPaciente").Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public string UpdatePaciente(PacienteModel Paciente)
        {

            var values = new Dictionary<string, string>{
                  { "usu_nome", Paciente.usu_nome},
                  { "email", Paciente.email },
                  { "telefone", Paciente.telefone },
                };

            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            var stringContent = new StringContent(json);

            //Recebendo o token
            string token = GetToken();

            Token tokenDados = System.Text.Json.JsonSerializer.Deserialize<Token>(token);

            using (var client = new HttpClient())
            {
                if (!string.IsNullOrWhiteSpace(token))
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenDados.data);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                }

                var response = client.PostAsync(url + "api/Desafio/UpdatePaciente/", new StringContent(json, Encoding.UTF8, "application/json")).Result;

                return response.Content.ReadAsStringAsync().Result;
            }
        }

    }
}
