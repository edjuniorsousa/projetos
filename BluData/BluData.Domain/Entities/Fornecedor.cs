using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluData.Domain.Entities
{
    public class Fornecedor
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cnpjCpf { get; set; }
        public DateTime dataCadastro { get; set; }
        public DateTime dataNasc { get; set; }
        public string rg { get; set; }
        public string telefone { get; set; }
        public List<Empresa> empresa { get; set; }
    }
}
