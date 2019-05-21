using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDDD.MVC.Models.IntegrationModel.DDD.Models
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