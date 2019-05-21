using ProjetoDDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetoDDD.API.Results.Formacoes
{
    public class FormacaoListJson : IHttpActionResult
    {
        private IEnumerable<Formacao> _formacoes;
        HttpRequestMessage _request;

        public FormacaoListJson(IEnumerable<Formacao> formacoes, HttpRequestMessage request)
        {
            _formacoes = formacoes;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(HttpStatusCode.OK, _formacoes.Select(formacao => new
            {
                Curso = formacao.Curso,
                Status = formacao.Status,
                DataConclusao = formacao.DataConclusao,
                Pessoa = new
                {
                    Nome = formacao.Pessoa.Nome,
                    DataNascimento = formacao.Pessoa.DataNascimento,
                    ExperienciaTotal = formacao.Pessoa.ExperienciaTotal
                }
            }));

            return Task.FromResult(response);
        }
    }
}