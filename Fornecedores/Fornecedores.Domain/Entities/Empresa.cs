using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Domain.Entities
{
    public class Empresa
    {
        public int id { get; set; }
        public string nomeFantasia { get; set; }
        public string cnpj { get; set; }
        public string uf { get; set; }
        public virtual IEnumerable<Fornecedor> Fornecedores { get; set; }
    }
}
