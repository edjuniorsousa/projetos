using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDDD.MVC.Models.IntegrationModel.DDD.Models
{
    public class Formacao
    {
        public string Curso { get; set; }
        public string Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataConclusao { get; set; }
    }
}