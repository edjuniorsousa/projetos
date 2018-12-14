using Newtonsoft.Json;
using Repos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Repos.Controllers
{
    public class RepositorioController : Controller
    {
        #region método para listar repositorios do github
        public JsonResult GetRepositorio()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.github.com/users/edjuniorsousa/repos");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36");

            var json = httpClient.GetStringAsync(httpClient.BaseAddress).Result;
            var repositorioList = JsonConvert.DeserializeObject<Repositorio[]>(json).ToList();

            return Json(repositorioList, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region método para pesquisar repositorios do github
        public JsonResult GetPesquisaRepositorio(Repositorio repos)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36");

                HttpResponseMessage response = client.GetAsync("https://api.github.com/search/repositories?q=" + repos.name).Result;
                response.EnsureSuccessStatusCode();
                string conteudo =
                    response.Content.ReadAsStringAsync().Result;
                dynamic resultado = JsonConvert.DeserializeObject(conteudo);

                Repositorio repo = new Repositorio();

                repo.name = resultado.name;
                repo.description = resultado.description;
                repo.language = resultado.language;
                repo.updated_at = resultado.updated_at;
                repo.full_name = resultado.full_name_;
                repo.contributors_url = resultado.contributors_url;

                return Json(repo, JsonRequestBehavior.AllowGet);


            }
        }
        #endregion

        #region método para adicionar repositorios aos favoritos
        [HttpPost]
        public JsonResult AdicionarRepositorio(Repositorio repos)
        {
            if (repos != null)
            {
                RepositoriosEntities entity = new RepositoriosEntities();
                Repositorio repo = entity.Repositorios.FirstOrDefault(x => x.id == repos.id);
                if (repo != null)
                {
                    throw new System.Exception("Repositório já cadastrado nos favoritos, " + repo.name);
                }
                else
                {

                    using (var db = new RepositoriosEntities())
                    {
                        db.Repositorios.Add(repos);
                        db.SaveChanges();

                        return Json(new { success = true });
                    }
                }
            }
            return Json(new { success = false });
        }
        #endregion

        #region método para listar repositorios favoritos
        public JsonResult GetRepositoriosFavoritos()
        {
            using (var db = new RepositoriosEntities())
            {
                List<Repositorio> listarProdutos = db.Repositorios.ToList();

                return Json(listarProdutos, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}