using ProjetoDDD.Domain.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetoDDD.API.Results.Formacoes
{
    public class FormacaoJson : IHttpActionResult
    {
        private Formacao _formacao;
        HttpRequestMessage _request;

        public string Curso { get; set; }
        public string Status { get; set; }
        public DateTime DataConclusao { get; set; }

        public FormacaoJson(Formacao formacao, HttpRequestMessage request)
        {
            _formacao = formacao;
            _request = request;
        }

        public FormacaoJson(Formacao formacao)
        {
            Curso = formacao.Curso;
            Status = formacao.Status;
            DataConclusao = formacao.DataConclusao;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response;

            if (_formacao == null)
            {
                response = _request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                response = _request.CreateResponse(HttpStatusCode.OK, new FormacaoJson(_formacao));
            }

            return Task.FromResult(response);
        }
    }
}