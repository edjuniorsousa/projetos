using ProjetoDDD.API.Filters;
using ProjetoDDD.API.Results.Formacoes;
using ProjetoDDD.API.ViewModels;
using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Entities;
using System.Web.Http;

namespace ProjetoDDD.API.Controllers
{
    public class FormacoesController : ApiController
    {
        private readonly IFormacaoAppService _formacaoApp;

        public FormacoesController(IFormacaoAppService formacaoApp)
        {
            _formacaoApp = formacaoApp;
        }

        // GET: api/Formacoes
        public FormacaoListJson Get()
        {
            var formacoes = _formacaoApp.GetAll();

            var data = new FormacaoListJson(formacoes, Request);

            return data;
        }

        // GET: api/Formacoes/5
        public FormacaoJson Get(int id)
        {
            var formacao = _formacaoApp.GetById(id);

            var data = new FormacaoJson(formacao, Request);

            return data;
        }

        // POST: api/Formacoes
        [ValidateModelState]
        public IHttpActionResult Post(FormacaoViewModel model)
        {
            var formacaoDomain = model.Map(new Formacao());

            _formacaoApp.Add(formacaoDomain);

            return Ok(model);
        }

        // PUT: api/Formacoes/5
        [ValidateModelState]
        public IHttpActionResult Put(int id, FormacaoViewModel model)
        {
            var formacao = _formacaoApp.GetById(id);

            if (formacao == null) return NotFound();

            var formacaoDomain = model.Map(formacao);

            _formacaoApp.Update(formacaoDomain);

            return Ok(formacao);
        }

        // DELETE: api/Formacoes/5
        public IHttpActionResult Delete(int id)
        {
            var formacao = _formacaoApp.GetById(id);

            if (formacao == null) return NotFound();

            _formacaoApp.Remove(formacao);

            return Ok(formacao);
        }
    }
}
