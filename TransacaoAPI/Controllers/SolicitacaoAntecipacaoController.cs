using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransacaoAPI.Repositorio;
using TransacaoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace TransacaoAPI.Controllers
{
    [Route("api/[Controller]")]
    public class SolicitacaoAntecipacaoController : Controller
    {
        private readonly ISolicitacaoAntecipacaoRepository _solicitacaoRepository;
        private readonly ITransacaoRepository _transacaoRepository;
        SolicitacaoAntecipacao solicita = new SolicitacaoAntecipacao();
        public SolicitacaoAntecipacaoController(ISolicitacaoAntecipacaoRepository solicitacaoRepo, ITransacaoRepository transaRepository)
        {
            _solicitacaoRepository = solicitacaoRepo;
            _transacaoRepository = transaRepository;
        }
        [HttpGet]
        public IEnumerable<SolicitacaoAntecipacao> GetAll()
        {

            var resultado = _solicitacaoRepository.GetAll();

            //foreach (var solicita in resultado)
            //    solicita..ValorSolicitacaoAntecipacao = transacao.CalculaValorSolicitacaoAntecipacao(transacao.ValorRepasse, transacao.NumeroParcelas);
            return resultado;


        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var resultado = _solicitacaoRepository.Find(id);
                if (resultado == null)
                    return NotFound();
                return new ObjectResult(resultado);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        public IActionResult Post([FromBody] int id)
        {
            try
            {
                //var trans = new TransacaoRepository();
                var resultado = _transacaoRepository.Find(1);

                if (resultado.SolicitacoesAntecipacao.Count == 0)
                {
                    var valorSolicitacaoAntecipacao = resultado.CalculaValorSolicitacaoAntecipacao(resultado.ValorRepasse, resultado.NumeroParcelas);
                    SolicitacaoAntecipacao solicita = new SolicitacaoAntecipacao()
                    {
                        DataSolicitacao = DateTime.Now,
                        ValorTotalTransacao = resultado.ValorTransacao,
                        ValorTotalRepasse = (double)resultado.ValorRepasse - valorSolicitacaoAntecipacao,
                        Status = "A", //em análise
                        TransacaoId = resultado.Id
                    };
                    //solicitacao = solicita;

                    _solicitacaoRepository.Add(solicita);

                    return new OkObjectResult(new { mensagem = "Solicitacão cadastrada com sucesso" });
                }
                else
                {
                    return new ObjectResult(new { mensagem = "Já existe uma Solicitação de Antecipacão de recebíveis cadastrada para esta Transacão." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
        [HttpGet("{dataInicial}/{dataFinal}")]
        public IActionResult Get(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                var resultado = _solicitacaoRepository.BuscaPorPeriodo(dataInicial, dataFinal);
                if (resultado == null)                    
                    return NotFound(new
                    {
                        mensagem = string.Format("Nenhuma solicitação encontrada no intervalo de {0} a {1}",
                            dataInicial.ToShortDateString(),
                            dataFinal.ToShortDateString())
                    });
               
                return new ObjectResult(resultado);
            }
            catch
            {
                return StatusCode(500);
            }
        }


    }

}
