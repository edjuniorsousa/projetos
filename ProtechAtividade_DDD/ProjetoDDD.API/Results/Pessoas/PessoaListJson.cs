using ProjetoDDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetoDDD.API.Results.Pessoas
{
    public class PessoaListJson : IHttpActionResult
    {
        private IEnumerable<Pessoa> _pessoas;
        HttpRequestMessage _request;

        public PessoaListJson(IEnumerable<Pessoa> pessoas, HttpRequestMessage request)
        {
            _pessoas = pessoas;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(HttpStatusCode.OK, _pessoas.Select(pessoa => new 
            {
                Nome = pessoa.Nome,
                DataNascimento = pessoa.DataNascimento,
                ExperienciaTotal = pessoa.ExperienciaTotal
            }));

            return Task.FromResult(response);
        }
    }
}