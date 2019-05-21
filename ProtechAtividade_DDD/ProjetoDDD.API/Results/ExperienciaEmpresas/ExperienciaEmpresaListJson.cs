using ProjetoDDD.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetoDDD.API.Results.ExperienciaEmpresas
{
    public class ExperienciaEmpresaListJson : IHttpActionResult
    {
        private IEnumerable<ExperienciaEmpresa> _experiencias;
        HttpRequestMessage _request;

        public ExperienciaEmpresaListJson(IEnumerable<ExperienciaEmpresa> experiencias, HttpRequestMessage request)
        {
            _experiencias = experiencias;
            _request = request;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = _request.CreateResponse(HttpStatusCode.OK, _experiencias.Select(experiencia => new
            {
                Empresa = experiencia.Empresa,
                Cargo = experiencia.Cargo,
                DataInicio = experiencia.DataInicio,
                DataFim = experiencia.DataFim,
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