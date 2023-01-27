using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TaskTecherDiogo2.Interface;
using TaskTecherDiogo2.Services;
using static TaskTecherDiogo2.Models.Metodos;

namespace TaskTecherDiogo2.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {
        private readonly InterfaceSimulacao _simulation;

        public HomeController(InterfaceSimulacao simulacao)
        {
            _simulation = simulacao;
        }

        [HttpPost("SimulacaoFINAZ")]
        public Retorno CalcularMargem([FromBody] Requisicao requisicao)
        {
            try
            {
                var response = _simulation.CalcularMargem(requisicao);
                return response;
            }
            catch (Exception exception)
            {
                throw new Exception("Não foi possível simular", exception);
            }

        }

    }
}
