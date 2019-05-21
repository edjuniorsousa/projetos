using ProjetoDDD.Domain.Entities;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetoDDD.API.Results.Experiencias
{
    public class ExperienciaJson : IHttpActionResult
    {
        private Experiencia _experiencia;
        HttpRequestMessage _request;

        public string Tecnologia { get; set; }
        public int TempoExperiencia { get; set; }
        public string DetalheExperiencia { get; set; }

        public ExperienciaJson(Experiencia experiencia, HttpRequestMessage request)
        {
            _experiencia = experiencia;
            _request = request;
        }

        public ExperienciaJson(Experiencia experiencia)
        {
            Tecnologia = experiencia.Tecnologia;
            TempoExperiencia = experiencia.TempoExperiencia;
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
                response = _request.CreateResponse(HttpStatusCode.OK, new ExperienciaJson(_experiencia));
            }

            return Task.FromResult(response);
        }
    }
}