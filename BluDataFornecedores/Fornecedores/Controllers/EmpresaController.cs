using Fornecedores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fornecedores.Controllers
{
    public class EmpresaController : Controller
    {
        public JsonResult GetEmpresa()
        {
            using (var db = new BluDataDBEntities())
            {
                try
                {
                    var listarEmpresas = db.Empresas.GroupJoin(db.Fornecedors, emp => emp.id,
                   forn => forn.idEmpresa, (emp, forn) => new { Fornecedor = forn, Empresa = emp })
                   .Select(x => new
                   {
                       x.Empresa.id,
                       x.Empresa.nomeFantasia,
                       x.Empresa.cnpj,
                       x.Empresa.uf
                   });

                    var listarEmpresasList = listarEmpresas.ToList();

                    return Json(listarEmpresasList, JsonRequestBehavior.AllowGet);

                }
                catch (Exception e)
                {
                    throw e;
                }

            }

        }
        #region Método para cadastrar empresa - CREATE
        //POST Empresa/CadastrarEmpresa
        [HttpPost]
        public JsonResult CadastrarEmpresa(Empresa empresa)
        {

            if (empresa.nomeFantasia != null && empresa.uf != null && empresa.cnpj != null)
            {
                if (!Fornecedores.Validacoes.Cnpj.ValidaCnpj(empresa.cnpj))
                {
                    
                    throw new Exception("Por favor, informe um CNPJ válido!");
                }
                else
                {
                    using (var db = new BluDataDBEntities()) 
                    {
                        db.Empresas.Add(empresa);
                        db.SaveChanges();

                        return Json(new { success = true });
                    }
                }
                
            }
            return Json(new { success = false });
        }
        #endregion
    }
}