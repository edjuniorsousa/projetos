//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Fornecedores.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Empresa
    {
        public Empresa()
        {
            this.Fornecedors = new HashSet<Fornecedor>();
        }

        public int id { get; set; }
        public string nomeFantasia { get; set; }
        public string cnpj { get; set; }

        public string _cnpj
        {
            get
            {
                return cnpj;
            }
            set
            {
                if (!Fornecedores.Validacoes.Cnpj.ValidaCnpj(cnpj))
                {
                    throw new Exception("Por favor, informe um CNPJ válido!");
                }
                cnpj = value;
            }
        }

        public string uf { get; set; }

        public virtual ICollection<Fornecedor> Fornecedors { get; set; }
    }
}
