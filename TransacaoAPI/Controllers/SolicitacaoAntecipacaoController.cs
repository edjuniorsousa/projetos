using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TransacaoAPI.Repositorio;
using TransacaoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

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

        [HttpPost("{id}")]
        //[Route("api/[Controller]/{id}")]        
        public ActionResult Post(int id)
        {
            try
            {
                //var trans = new TransacaoRepository();
                var resultado = _transacaoRepository.Find(id);

                if (resultado.SolicitacoesAntecipacao.Count == 0)
                {
                    var valorSolicitacaoAntecipacao = resultado.CalculaValorSolicitacaoAntecipacao(resultado.ValorRepasse, resultado.NumeroParcelas);
                    SolicitacaoAntecipacao solicita = new SolicitacaoAntecipacao()
                    {
                        DataSolicitacao = DateTime.Today,
                        ValorTotalTransacao = resultado.ValorTransacao,
                        ValorTotalRepasse = (double)resultado.ValorRepasse - valorSolicitacaoAntecipacao,
                        Status = "A", //em análise
                        DataAnaliseInicio = DateTime.Now,
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
                var resultado = _solicitacaoRepository.GetAll().ToList();
                if (resultado.Count == 0)
                    return NotFound(new
                    {
                        mensagem = string.Format("Nenhuma solicitação encontrada no intervalo de {0} a {1}",
                            dataInicial.ToShortDateString(),
                            dataFinal.ToShortDateString())
                    });
                return new ObjectResult(resultado.Where(p => p.DataSolicitacao >= dataInicial && p.DataSolicitacao <= dataFinal).ToList());
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Aprovar(int id)
        {
            try
            {
                var resultadoSolicitacao = _solicitacaoRepository.BuscaPorTransacao(id);
                var resultadoTransacao = _transacaoRepository.Busca(id);
                if (resultadoSolicitacao == null)
                    return NotFound();
                else
                {
                    resultadoSolicitacao.DataAnaliseFim = DateTime.Now;
                    resultadoSolicitacao.Status = "F";//Finalizado
                    resultadoSolicitacao.Resultado = "Aprovado";

                    _solicitacaoRepository.Update(resultadoSolicitacao);
                }
                if (resultadoTransacao == null)
                    return NotFound();
                else
                {
                    resultadoTransacao.DataRepasse = DateTime.Now;
                    resultadoTransacao.Confirmacao = "Aprovado";
                    _transacaoRepository.Update(resultadoTransacao);
                }
                return new OkObjectResult(new { mensagem = "Solicitacao aprovada" });


            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }

        }
        [HttpGet]
        [Route("api/[Controller]/{Type:string}")]
        public IActionResult ListarSolicitacaoAndamento(string Status)
        {
            try
            {
                var resultado = _solicitacaoRepository.GetAll().ToList();
                if (resultado.Count == 0)
                    return NotFound(new
                    {
                        mensagem = string.Format("Nenhuma solicitação em andamento encontrada")
                    }); 
                return new ObjectResult(resultado.Where(p => p.Status== Status).ToList());
            }
            catch
            {
                return StatusCode(500);
            }
        }



    }

}
