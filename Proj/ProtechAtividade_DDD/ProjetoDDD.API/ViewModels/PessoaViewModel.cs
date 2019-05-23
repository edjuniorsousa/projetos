using ProjetoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDDD.API.ViewModels
{
    public class PessoaViewModel
    {
        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150, ErrorMessage = "Campo {0} máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Campo {0} minimo {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo data de nascimento")]
        [DisplayName("Data de nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha o campo experiência total")]
        [Range(typeof(int), "0", "99")]
        [DisplayName("Experiência total")]
        public int? ExperienciaTotal { get; set; }

        public IEnumerable<ExperienciaViewModel> Experiencia { get; set; }

        public IEnumerable<ExperienciaEmpresaViewModel> ExperienciaEmpresas { get; set; }

        public IEnumerable<FormacaoViewModel> Formacao { get; set; }

        public Pessoa Map(Pessoa pessoa)
        {
            if (pessoa != null)
            {
                pessoa.Nome = Nome;
                pessoa.DataNascimento = DataNascimento.Value;
                pessoa.ExperienciaTotal = ExperienciaTotal.Value;
            }

            return pessoa;
        }
    }
}