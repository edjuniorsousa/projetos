using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProtechAtividade_DDD.MVC.Models.Integration.DDD.Models
{
    public class PessoaLista
    {
        public int PessoaId => 1;
        public string Nome { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public int ExperienciaTotal { get; set; }
    }
}