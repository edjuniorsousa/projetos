using Fornecedores.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Fornecedores.Domain.Entities;
using Fornecedores.MVC.ViewModels;

namespace Fornecedores.MVC.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly EmpresaRepository _empresaRepository = new EmpresaRepository();
        // GET: Empresa
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Empresa>, IEnumerable<EmpresaViewModel>>(_empresaRepository.GetAll());

            return View(clienteViewModel);
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            ViewBag.Ufs = new SelectList
                (
                    new EmpresaViewModel().ListaUfs(),
                    "uf"
                );
            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpresaViewModel empresa)
        {
            ViewBag.Ufs = new SelectList
                (
                    new EmpresaViewModel().ListaUfs(),
                    "uf",
                    empresa.uf

                );

            if (ModelState.IsValid)
            {
                var empresaDomain = Mapper.Map<EmpresaViewModel, Empresa>(empresa);
                _empresaRepository.Add(empresaDomain);
                return RedirectToAction("Index");
            }
            return View(empresa);
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Empresa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
