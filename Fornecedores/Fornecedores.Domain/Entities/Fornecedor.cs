using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Domain.Entities
{
    public class Fornecedor
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cnpjOuCpf { get; set; }
        public int idEmpresa { get; set; }
        public string tipo { get; set; }
        public DateTime dataCadastro { get; set; }
        public string telefone { get; set; }
        public string rg { get; set; }
        public DateTime dataNasc { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
