using ProjetoDDD.API.Filters;
using ProjetoDDD.API.Results.ExperienciaEmpresas;
using ProjetoDDD.API.ViewModels;
using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Entities;
using System.Web.Http;

namespace ProjetoDDD.API.Controllers
{
    public class ExperienciaEmpresasController : ApiController
    {
        private readonly IExperienciaEmpresaAppService _experienciaApp;

        public ExperienciaEmpresasController(IExperienciaEmpresaAppService experienciaApp)
        {
            _experienciaApp = experienciaApp;
        }

        // GET: api/ExpericiaEmpresas
        public ExperienciaEmpresaListJson Get()
        {
            var experiencias = _experienciaApp.GetAll();

            var data = new ExperienciaEmpresaListJson(experiencias, Request);

            return data;
        }

        // GET: api/ExpericiaEmpresas/5
        public ExperienciaEmpresaJson Get(int id)
        {
            var experiencia = _experienciaApp.GetById(id);

            var data = new ExperienciaEmpresaJson(experiencia, Request);

            return data;
        }

        // POST: api/ExpericiaEmpresas
        [ValidateModelState]
        public IHttpActionResult Post(ExperienciaEmpresaViewModel model)
        {
            var experienciaDomain = model.Map(new ExperienciaEmpresa());

            _experienciaApp.Add(experienciaDomain);

            return Ok(model);
        }

        // PUT: api/ExpericiaEmpresas/5
        [ValidateModelState]
        public IHttpActionResult Put(int id, ExperienciaEmpresaViewModel model)
        {
            var experiencia = _experienciaApp.GetById(id);

            if (experiencia == null) return NotFound();

            var experienciaDomain = model.Map(experiencia);

            _experienciaApp.Update(experienciaDomain);

            return Ok(experiencia);
        }

        // DELETE: api/ExpericiaEmpresas/5
        public IHttpActionResult Delete(int id)
        {
            var experiencia = _experienciaApp.GetById(id);

            if (experiencia == null) return NotFound();

            _experienciaApp.Remove(experiencia);

            return Ok(experiencia);
        }
    }
}
