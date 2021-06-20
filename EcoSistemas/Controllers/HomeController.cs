using EcoSistemas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace EcoSistemas.Controllers
{
    public class HomeController : ApiController
    {


        public IActionResult Index()
        {
            //Recebendo o valor do Token
            var tokenDados = JsonConvert.DeserializeObject<Token>(GetToken());
            //Exibindo as mensagens
            ViewBag.msg = tokenDados.mensagem;
            ViewBag.proxima = tokenDados.proximaEtapa;

            return View();
        }



    }
}
