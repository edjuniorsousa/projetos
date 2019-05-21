using ProjetoDDD.MVC.Models.IntegrationModel.DDD;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ProjetoDDD.MVC.Controllers
{
    public class PessoasController : Controller
    {
        private readonly IDDDApi _api;

        public PessoasController(IDDDApi api)
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

        // GET: Pessoas/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var repository = await _api.GetPersonById(id);

            if (repository == null)
            {
                return View("Error");
            }

            return View(repository);
        }

        //// GET: Pessoas/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Pessoas/Create
        //[HttpPost]
        //public ActionResult Create(PessoaViewModel pessoa)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var pessoaDomain = Mapper.Map<PessoaViewModel, Pessoa>(pessoa);
        //        _pessoaApp.Add(pessoaDomain);

        //        return RedirectToAction("Index");
        //    }

        //    return View(pessoa);
        //}

        //// GET: Pessoas/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    var pessoa = _pessoaApp.GetById(id);
        //    var pessoaViewModel = Mapper.Map<Pessoa, PessoaViewModel>(pessoa);

        //    return View(pessoaViewModel);
        //}

        //// POST: Pessoas/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(PessoaViewModel pessoa)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var pessoaDomain = Mapper.Map<PessoaViewModel, Pessoa>(pessoa);
        //        _pessoaApp.Update(pessoaDomain);

        //        return RedirectToAction("Index");
        //    }

        //    return View(pessoa);
        //}

        //// GET: Pessoas/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    var pessoa = _pessoaApp.GetById(id);
        //    var pessoaViewModel = Mapper.Map<Pessoa, PessoaViewModel>(pessoa);

        //    return View(pessoaViewModel);
        //}

        //// POST: Pessoas/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var pessoa = _pessoaApp.GetById(id);
        //    _pessoaApp.Remove(pessoa);

        //    return RedirectToAction("Index");
        //}
    }
}