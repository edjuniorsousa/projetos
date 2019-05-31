using Fornecedores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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
                catch (Exception e)
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
                BluDataDBEntities entity = new BluDataDBEntities();
                Fornecedor forn = entity.Fornecedors.FirstOrDefault(x => x.cnpjOuCpf == fornecedor.cnpjOuCpf);
                if (forn != null)
                {
                    TempData["mensagemErro"] = "Já existe um fornecedor cadastrado com este CPF/CNPJ, " + forn.nome;
                    //return RedirectToAction("Index", "Home");
                    //throw new System.Exception("Já existe um fornecedor cadastrado com este CPF/CNPJ, " + forn.nome);
                }
                else
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
                                        var estado = db.Empresas.Where(e => e.id == fornecedor.idEmpresa)
                                            .Select(x => new
                                            {
                                                x.uf
                                            }).First();
                                        if (DateTime.Now.Year - fornecedor.dataNasc.Value.Date.Year < 18 && estado.uf == "PR")
                                            return Json(new { success = false });
                                        else
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
                }

            }
            return Json(new { success = false });



        }
        #endregion


    }
}