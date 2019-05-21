using ProjetoDDD.Domain.Entities;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetoDDD.API.Results.ExperienciaEmpresas
{
    public class ExperienciaEmpresaJson : IHttpActionResult
    {
        private ExperienciaEmpresa _experiencia;
        HttpRequestMessage _request;

        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string DetalheExperiencia { get; set; }

        public ExperienciaEmpresaJson(ExperienciaEmpresa experiencia, HttpRequestMessage request)
        {
            _experiencia = experiencia;
            _request = request;
        }

        public ExperienciaEmpresaJson(ExperienciaEmpresa experiencia)
        {
            Empresa = experiencia.Empresa;
            Cargo = experiencia.Cargo;
            DataInicio = experiencia.DataInicio;
            DataFim = experiencia.DataFim;
            DetalheExperiencia = experiencia.DetalheExperiencia;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response;

            if (_experiencia == null)
            {
                response = _request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                response = _request.CreateResponse(HttpStatusCode.OK, new ExperienciaEmpresaJson(_experiencia));
            }

            return Task.FromResult(response);
        }
    }
}