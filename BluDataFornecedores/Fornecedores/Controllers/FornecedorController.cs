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
        #region Método para cadastrar fornecedor - CREATE
        //POST Fornecedor/CadastrarEmpresa
        [HttpPost]
        public JsonResult CadastrarFornecedor(Fornecedor fornecedor)
        {

            if (fornecedor != null)
            {
                if (fornecedor.nome != null && fornecedor.idEmpresa != null && fornecedor.telefone != null && fornecedor.tipo != null)
                {
                    //Pessoa jurídica
                    if (fornecedor.cnpjOuCpf != null)
                    {
                        if (fornecedor.tipo == "PJ" && fornecedor.cnpjOuCpf.Length > 11)
                        {
                            if (!Fornecedores.Validacoes.Cnpj.ValidaCnpj(fornecedor.cnpjOuCpf))
                            {

                                throw new Exception("Por favor, informe um CNPJ válido!");
                            }
                            else
                            {
                                using (var db = new BluDataDBEntities())
                                {
                                    db.Fornecedors.Add(fornecedor);
                                    db.SaveChanges();

                                    return Json(new { success = true });
                                }

                            }
                        }
                    }
                    //Pessoa física
                    if (fornecedor.cnpjOuCpf != null && fornecedor.rg != null && fornecedor.dataNasc != null)
                    {
                        if (fornecedor.tipo == "PF" && fornecedor.cnpjOuCpf.Length <= 11)
                        {
                            if (!Fornecedores.Validacoes.Cpf.ValidaCpf(fornecedor.cnpjOuCpf))
                            {

                                throw new Exception("Por favor, informe um CPF válido!");
                            }
                            else
                            {
                                using (var db = new BluDataDBEntities())
                                {
                                    db.Fornecedors.Add(fornecedor);
                                    db.SaveChanges();

                                    return Json(new { success = true });
                                }

                            }


                        }
                    }
                }

            }
            return Json(new { success = false });



        }
        #endregion
    }
}