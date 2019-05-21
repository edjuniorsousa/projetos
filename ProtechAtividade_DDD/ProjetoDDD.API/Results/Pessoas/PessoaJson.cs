using ProjetoDDD.API.Results.ExperienciaEmpresas;
using ProjetoDDD.API.Results.Experiencias;
using ProjetoDDD.API.Results.Formacoes;
using ProjetoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetoDDD.API.Results.Pessoas
{
    public class PessoaJson : IHttpActionResult
    {
        private Pessoa _pessoa;
        HttpRequestMessage _request;

        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<FormacaoJson> Formacao { get; set; }
        public int ExperienciaTotal { get; set; }
        public ICollection<ExperienciaJson> Experiencia{ get; set; }
        public ICollection<ExperienciaEmpresaJson> ExperienciaEmpresas { get; set; }

        public PessoaJson(Pessoa pessoa, HttpRequestMessage request)
        {
            _pessoa = pessoa;
            _request = request;
        }

        public PessoaJson(Pessoa pessoa)
        {
            Nome = pessoa.Nome;
            DataNascimento = pessoa.DataNascimento;
            Formacao = pessoa.Formacao.Select(formacao => new FormacaoJson(formacao)).ToList();
            ExperienciaTotal = pessoa.ExperienciaTotal;
            Experiencia = pessoa.Experiencia.Select(experiencia => new ExperienciaJson(experiencia)).ToList();
            ExperienciaEmpresas = pessoa.ExperienciaEmpresas.Select(formacao => new ExperienciaEmpresaJson(formacao)).ToList();
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response;

            if (_pessoa == null)
            {
                response = _request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                response = _request.CreateResponse(HttpStatusCode.OK, new PessoaJson(_pessoa));
            }

            return Task.FromResult(response);
        }
    }
}