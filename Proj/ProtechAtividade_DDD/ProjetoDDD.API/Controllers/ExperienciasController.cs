using ProjetoDDD.API.Filters;
using ProjetoDDD.API.Results.Experiencias;
using ProjetoDDD.API.ViewModels;
using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Entities;
using System.Web.Http;

namespace ProjetoDDD.API.Controllers
{
    public class ExperienciasController : ApiController
    {
        private readonly IExperienciaAppService _experienciaApp;

        public ExperienciasController(IExperienciaAppService experienciaApp)
        {
            _experienciaApp = experienciaApp;
        }

        // GET: api/Experiencias
        public ExperienciaListJson Get()
        {
            var experiencias = _experienciaApp.GetAll();

            var data = new ExperienciaListJson(experiencias, Request);

            return data;
        }

        // GET: api/Experiencias/5
        public ExperienciaJson Get(int id)
        {
            var experiencia = _experienciaApp.GetById(id);

            var data = new ExperienciaJson(experiencia, Request);

            return data;
        }

        // POST: api/Experiencias
        [ValidateModelState]
        public IHttpActionResult Post(ExperienciaViewModel model)
        {
            var experienciaDomain = model.Map(new Experiencia());

            _experienciaApp.Add(experienciaDomain);

            return Ok(model);
        }

        // PUT: api/Experiencias/5
        [ValidateModelState]
        public IHttpActionResult Put(int id, ExperienciaViewModel model)
        {
            var experiencia = _experienciaApp.GetById(id);

            if (experiencia == null) return NotFound();

            var experienciaDomain = model.Map(experiencia);

            _experienciaApp.Update(experienciaDomain);

            return Ok(experiencia);
        }

        // DELETE: api/Experiencias/5
        public IHttpActionResult Delete(int id)
        {
            var experiencia = _experienciaApp.GetById(id);
            
            if (experiencia == null) return NotFound();

            _experienciaApp.Remove(experiencia);

            return Ok(experiencia);
        }
    }
}
