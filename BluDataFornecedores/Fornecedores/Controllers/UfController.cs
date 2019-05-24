using Fornecedores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fornecedores.Controllers
{
    public class UfController : Controller
    {
        public JsonResult GetUf()
        {
            using (var db = new BluDataDBEntities())
            {
                try
                {
                    var listarUfs = db.Ufs.ToList();

                    return Json(listarUfs, JsonRequestBehavior.AllowGet);

                }
                catch (Exception e)
                {
                    throw e;
                }

            }

        }
    }
}