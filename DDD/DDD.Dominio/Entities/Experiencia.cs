using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Dominio.Entities
{
    public class Experiencia
    {
        public int ExperienciaId { get; set; }
        public int PessoaId { get; set; }
        public string Tecnologia { get; set; }
        public int TempoExperiencia { get; set; }
        public string DetalheExperiencia { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
