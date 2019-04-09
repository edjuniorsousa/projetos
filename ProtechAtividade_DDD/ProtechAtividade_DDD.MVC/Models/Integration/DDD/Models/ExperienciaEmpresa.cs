using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProtechAtividade_DDD.MVC.Models.Integration.DDD.Models
{
    public class ExperienciaEmpresa
    {
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; }
        public string DetalheExperiencia { get; set; }
    }
}