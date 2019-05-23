using ProjetoDDD.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDDD.API.ViewModels
{
    public class ExperienciaEmpresaViewModel
    {
        [Required(ErrorMessage = "Preencha o campo empresa")]
        [MaxLength(150, ErrorMessage = "Campo {0} máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Campo {0} minimo {0} caracteres")]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "Preencha o campo cargo")]
        [MaxLength(150, ErrorMessage = "Campo {0} máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Campo {0} minimo {0} caracteres")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Preencha o campo data inicio")]
        [DisplayName("Data iniciio")]
        public DateTime? DataInicio { get; set; }

        [Required(ErrorMessage = "Preencha o campo data fim")]
        [DisplayName("Data fim")]
        public DateTime? DataFim { get; set; }

        [DisplayName("Detalhes")]
        public string DetalheExperiencia { get; set; }

        [Required(ErrorMessage = "Preencha o campo pessoa")]
        public int PessoaId { get; set; }

        public PessoaViewModel Pessoa { get; set; }

        public ExperienciaEmpresa Map(ExperienciaEmpresa experiencia)
        {
            if (experiencia != null)
            {
                experiencia.PessoaId = PessoaId;
                experiencia.Empresa = Empresa;
                experiencia.Cargo = Cargo;
                experiencia.DataInicio = DataInicio.Value;
                experiencia.DataFim = DataFim.Value;
            }

            return experiencia;
        }
    }
}