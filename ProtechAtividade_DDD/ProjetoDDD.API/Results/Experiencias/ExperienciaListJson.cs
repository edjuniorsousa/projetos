using ProjetoDDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetoDDD.API.Results.Experiencias
{
    public class ExperienciaListJson : IHttpActionResult
    {
        private IEnumerable<Experiencia> _experiencias;
        HttpRequestMessage _request;

        public ExperienciaListJson(IEnumerable<Experiencia> experiencias, HttpRequestMessage request)
        {
            _experiencias = experiencias;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(HttpStatusCode.OK, _experiencias.Select(experiencia => new
            {
                Tecnologia = experiencia.Tecnologia,
                TempoExperiencia = experiencia.TempoExperiencia,
                DetalheExperiencia = experiencia.DetalheExperiencia,
                Pessoa = new
                {
                    Nome = experiencia.Pessoa.Nome,
                    DataNascimento = experiencia.Pessoa.DataNascimento,
                    ExperienciaTotal = experiencia.Pessoa.ExperienciaTotal
                }
            }));

            return Task.FromResult(response);
        }
    }
}