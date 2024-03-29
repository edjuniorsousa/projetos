﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDDD.MVC.Models.IntegrationModel.DDD.Models
{
    public class Pessoa
    {
        public string Nome { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public ICollection<Formacao> Formacao { get; set; }
        public int ExperienciaTotal { get; set; }
        public ICollection<Experiencia> Experiencia { get; set; }
        public ICollection<ExperienciaEmpresa> ExperienciaEmpresas { get; set; }
    }
}