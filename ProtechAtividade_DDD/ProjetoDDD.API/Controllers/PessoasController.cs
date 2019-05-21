using ProjetoDDD.API.Filters;
using ProjetoDDD.API.Results.Pessoas;
using ProjetoDDD.API.ViewModels;
using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Entities;
using System.Web.Http;

namespace ProjetoDDD.API.Controllers
{
    public class PessoasController : ApiController
    {
        private readonly IPessoaAppService _pessoaApp;

        public PessoasController(IPessoaAppService pessoaApp)
        {
            _pessoaApp = pessoaApp;
        }

        // GET: api/Pessoas
        public PessoaListJson Get()
        {
            var pessoas = _pessoaApp.GetAll();

            var data = new PessoaListJson(pessoas, Request);

            return data;
        }

        // GET: api/Pessoas/5
        public PessoaJson Get(int id)
        {
            var pessoa = _pessoaApp.GetById(id);

            var data = new PessoaJson(pessoa, Request);

            return data;
        }

        // POST: api/Pessoas
        [ValidateModelState]
        public IHttpActionResult Post(PessoaViewModel model)
        {
            var pessoaDomain = model.Map(new Pessoa());

            _pessoaApp.Add(pessoaDomain);

            return Ok(model);
        }

        // PUT: api/Pessoas/5
        [ValidateModelState]
        public IHttpActionResult Put(int id, PessoaViewModel model)
        {
            var pessoa = _pessoaApp.GetById(id);

            if (pessoa == null) return NotFound();

            var pessoaDomain = model.Map(pessoa);

            _pessoaApp.Update(pessoaDomain);

            return Ok(pessoa);
        }

        // DELETE: api/Pessoas/5
        public IHttpActionResult Delete(int id)
        {
            var pessoa = _pessoaApp.GetById(id);

            if (pessoa == null) return NotFound();

            _pessoaApp.Remove(pessoa);

            return Ok(pessoa);
        }
    }
}
