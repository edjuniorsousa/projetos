using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProtechAtividade_DDD.MVC.ViewModels
{
    public class PessoaViewModel
    {
        [Key]
        public int PessoaId { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo data de nascimento")]
        [DisplayName("Data de nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha o campo experiência total")]
        [Range(typeof(int), "0", "99")]
        [DisplayName("Experiência total")]
        public int? ExperienciaTotal { get; set; }
    }
}