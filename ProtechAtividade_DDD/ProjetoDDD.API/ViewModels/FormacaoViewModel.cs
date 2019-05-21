using ProjetoDDD.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDDD.API.ViewModels
{
    public class FormacaoViewModel
    {
        [Required(ErrorMessage = "Preencha o campo curso")]
        [MaxLength(150, ErrorMessage = "Campo {0} máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Campo {0} minimo {0} caracteres")]
        public string Curso { get; set; }

        [Required(ErrorMessage = "Preencha o campo status")]
        [MaxLength(150, ErrorMessage = "Campo {0} máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Campo {0} minimo {0} caracteres")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Preencha o campo data conclusão")]
        [DisplayName("Data conclusão")]
        public DateTime? DataConclusao { get; set; }

        [Required(ErrorMessage = "Preencha o campo pessoa")]
        public int PessoaId { get; set; }

        public PessoaViewModel Pessoa { get; set; }

        public Formacao Map(Formacao formacao)
        {
            if (formacao != null)
            {
                formacao.PessoaId = PessoaId;
                formacao.Curso = Curso;
                formacao.Status = Status;
                formacao.DataConclusao = DataConclusao.Value;
            }

            return formacao;
        }
    }
}