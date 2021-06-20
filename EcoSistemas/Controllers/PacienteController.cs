using EcoSistemas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace EcoSistemas.Controllers
{

    public class RootObj
    {
        public List<Paciente> data { get; set; }
    }

    public class Paciente
    {
        public string usu_nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
    }

    public class PacienteController : ApiController
    {

        public IActionResult Index()
        {
            //Recebendo a lista de pacientes
            string json = GetPaciente();

            dynamic tokenDados = JsonConvert.DeserializeObject<Passo>(json);
            //Exibindo as mensagens
            ViewBag.msg = tokenDados.mensagem;
            ViewBag.proxima = tokenDados.proximaEtapa;
            //Passando os dados para view
            dynamic dobj = JsonConvert.DeserializeObject<dynamic>(json);
            ViewBag.usu_nome = dobj["data"]["usu_nome"];
            ViewBag.email = dobj["data"]["email"];
            ViewBag.telefone = dobj["data"]["telefone"];

            return View();
        }



    }
}
