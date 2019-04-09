using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProtechAtividade_DDD.MVC.Models.Integration.DDD.Models
{
    public class Formacao
    {
        public string Curso { get; set; }
        public string Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataConclusao { get; set; }
    }
}