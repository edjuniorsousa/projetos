using Fornecedores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fornecedores.Controllers
{
    public class FornecedorController : Controller
    {
        public JsonResult GetFornecedor()
        {
            using (var db = new BluDataDBEntities())
            {
                try
                {
                    var listarFornecedores = db.Fornecedors.Join(db.Empresas, forn => forn.idEmpresa,
                emp => emp.id, (forn, emp) => new { Fornecedor = forn, Empresa = emp })
                .Select(x => new
                {
                    x.Fornecedor.id,
                    x.Fornecedor.tipo,
                    x.Fornecedor.nome,
                    x.Empresa.nomeFantasia,
                    x.Fornecedor.cnpjOuCpf,
                    x.Fornecedor.dataCadastro,
                    x.Fornecedor.telefone,
                    x.Fornecedor.dataNasc,
                    x.Fornecedor.rg
                }).ToList();
                    var listarFornecedoresList = listarFornecedores.ToList();

                    return Json(listarFornecedoresList, JsonRequestBehavior.AllowGet);
                }
                catch(Exception e)
                {
                    throw e;
                }
                
            }

        }
    }
}