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

        [HttpPost]
        public ActionResult EditPaciente(PacienteModel Paciente)
        {
            //Atualizado os dados do paciente
            string json = UpdatePaciente(Paciente);

            dynamic tokenDados = JsonConvert.DeserializeObject<Passo>(json);
            ViewBag.msg = tokenDados.mensagem;

            //Passando os dados para view
            ViewBag.usu_nome = Paciente.usu_nome;
            ViewBag.email = Paciente.email;
            ViewBag.telefone = Paciente.telefone;

            return View();

        }


    }
}
