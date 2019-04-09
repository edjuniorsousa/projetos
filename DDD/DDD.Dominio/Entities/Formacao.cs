using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Dominio.Entities
{
    public class Formacao
    {
        public int FormacaoId { get; set; }
        public int PessoaId { get; set; }
        public string Curso { get; set; }
        public string Status { get; set; }
        public DateTime DataConclusao { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
