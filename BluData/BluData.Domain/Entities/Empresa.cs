using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluData.Domain.Entities
{
    public class Empresa
    {
        public int id { get; set; }
        public string uf { get; set; }
        public string nomeFantasia { get; set; }
        public string cnpj { get; set; }


    }
}
