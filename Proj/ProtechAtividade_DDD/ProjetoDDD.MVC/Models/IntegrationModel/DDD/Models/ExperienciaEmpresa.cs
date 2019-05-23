using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDDD.MVC.Models.IntegrationModel.DDD.Models
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