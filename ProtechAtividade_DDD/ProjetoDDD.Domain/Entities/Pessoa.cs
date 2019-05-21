using System;
using System.Collections.Generic;

namespace ProjetoDDD.Domain.Entities
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual ICollection<Formacao> Formacao { get; set; }
        public int ExperienciaTotal { get; set; }
        public virtual ICollection<Experiencia> Experiencia { get; set; }
        public virtual ICollection<ExperienciaEmpresa> ExperienciaEmpresas { get; set; }
    }
}
