using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_MVC_ANGULARJS.Models;

namespace CRUD_MVC_ANGULARJS.Controllers
{
    public class ProdutoController : Controller
    {
        #region método para listar produtos
        //Get Produto/ListarProdutos
        public JsonResult GetProduto()
        {
            using (var db = new ProdutosEntities())
            {
                List<Produto> listarProdutos = db.Produtoes.ToList();

                return Json(listarProdutos, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Método para Adicionar produto - CREATE
        //POST Produto/AdicionarProduto
        [HttpPost]
        public JsonResult AdicionarProduto(Produto produto)
        {
            if (produto != null)
            {
                using (var db = new ProdutosEntities())
                {
                    db.Produtoes.Add(produto);
                    db.SaveChanges();

                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }
        #endregion

        #region Método para Adicionar compra 
        //POST Produto/AdicionarCompra
        [HttpPost]
        public JsonResult AdicionarCompra(Compra compra)
        {
            if (compra != null)
            {
                using (var db = new ProdutosEntities())
                {
                    db.Compras.Add(compra);
                    db.SaveChanges();

                    return Json(new { success = true });
                }
            }
            return Json(new { success = false });
        }
        #endregion


        #region Método para editar produto - UPDATE
        [HttpPost]
        public JsonResult AtualizarProduto(Produto produto)
        {
            using (var db = new ProdutosEntities())
            {
                var produtoAtualizado = db.Produtoes.Find(produto.produtoId);
                if (produtoAtualizado == null)
                {
                    //retorna msg se o id nao existir
                    return Json(new { success = false });
                }
                else
                {
                    produtoAtualizado.descricao = produto.descricao;
                    produtoAtualizado.quantidade = produto.quantidade;
                    produtoAtualizado.dataCadastro = produto.dataCadastro;
                    produtoAtualizado.valor = produto.valor;

                    //salva alterações e retorna Json
                    db.SaveChanges();
                    return Json(new { success = true });
                }
            }
        }
        #endregion

        #region Método para Excluir produto - DELETE

        [HttpPost]
        public JsonResult Excluirproduto(int id)
        {
            using (var db = new ProdutosEntities())
            {
                var produto = db.Produtoes.Find(id);
                if (produto == null)
                {
                    return Json(new { success = false });
                }

                db.Produtoes.Remove(produto);
                db.SaveChanges();

                return Json(new { success = true });
            }
        }
        #endregion
    }
}