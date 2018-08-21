using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransacaoAPI.Repositorio;
using TransacaoAPI.Models;


namespace TransacaoAPI.Controllers
{
    [Route("api/[Controller]")]
    public class TransacaoController : Controller
    {
        private readonly ITransacaoRepository _transacaoRepository;
        public TransacaoController(ITransacaoRepository transacaoRepo)
        {
            _transacaoRepository = transacaoRepo;
        }
        [HttpGet]
        public IEnumerable<Transacao> GetAll()
        {

            var resultado =  _transacaoRepository.GetAll();

            foreach (var transacao in resultado)
                transacao.ValorSolicitacaoAntecipacao = transacao.CalculaValorSolicitacaoAntecipacao(transacao.ValorRepasse, transacao.NumeroParcelas);
            return resultado;


        }
        [HttpGet("{id}", Name = "GetTransacao")]
        public IActionResult GetById(int id)
        {
            var resultado = _transacaoRepository.Find(id);
            if (resultado == null)
                return NotFound();
            return new ObjectResult(resultado);
        }


    }
}
