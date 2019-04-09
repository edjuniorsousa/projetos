using ProtechAtividade_DDD.MVC.Models.Integration.DDD;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProtechAtividade_DDD.MVC.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IDDDApi _api;

        public PessoaController(IDDDApi api)
        {
            _api = api;
        }

        // GET: Pessoas
        public async Task<ActionResult> Index()
        {
            var repositories = await _api.GetAllPersons();

            if (repositories == null)
            {
                return View("Error");
            }

            return View(repositories);
        }

        // GET: Pessoas/Details/1
        public async Task<ActionResult> Details(int id)
        {
            var repository = await _api.GetPersonById(id);

            if (repository == null)
            {
                return View("Error");
            }

            return View(repository);
        }
    }
}
