using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Dominio.Entities
{
    public class ExperienciaEmpresa
    {
        public int ExperienciaEmpresaId { get; set; }
        public int PessoaId { get; set; }
        public string Empresa { get; set; }
        public string Cargo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string DetalheExperiencia { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
