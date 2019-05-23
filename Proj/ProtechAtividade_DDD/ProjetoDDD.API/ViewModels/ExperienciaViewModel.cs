using ProjetoDDD.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjetoDDD.API.ViewModels
{
    public class ExperienciaViewModel
    {
        [Required(ErrorMessage = "Preencha o campo tecnologia")]
        [MaxLength(150, ErrorMessage = "Campo {0} máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Campo {0} minimo {0} caracteres")]
        public string Tecnologia { get; set; }

        [Required(ErrorMessage = "Preencha o campo tempo de experiência")]
        [Range(typeof(int), "0", "99")]
        [DisplayName("Tempo de experiência")]
        public int? TempoExperiencia { get; set; }

        [DisplayName("Detalhes")]
        public string DetalheExperiencia { get; set; }

        [Required(ErrorMessage = "Preencha o campo pessoa")]
        public int PessoaId { get; set; }

        public PessoaViewModel Pessoa { get; set; }

        public Experiencia Map(Experiencia experiencia)
        {
            if (experiencia != null)
            {
                experiencia.PessoaId = PessoaId;
                experiencia.Tecnologia = Tecnologia;
                experiencia.TempoExperiencia = TempoExperiencia.Value;
                experiencia.DetalheExperiencia = DetalheExperiencia;
            }

            return experiencia;
        }
    }
}