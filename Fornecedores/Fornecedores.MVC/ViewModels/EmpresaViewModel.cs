using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fornecedores.MVC.ViewModels
{
    public class EmpresaViewModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Nome")]
        public string nomeFantasia { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ")]
        [MaxLength(14, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("CNPJ")]
        public string cnpj { get; set; }

        [Required(ErrorMessage = "Informe a Unidade Federativa")]
        [DisplayName("UF")]
        public string uf { get; set; }

        public virtual IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
        
        public List<EmpresaViewModel> ListaUfs()
        {
            return new List<EmpresaViewModel>
            {
                new EmpresaViewModel{ uf ="AC"},
                new EmpresaViewModel{ uf ="AL"},
                new EmpresaViewModel{ uf ="AP"},
                new EmpresaViewModel{ uf ="AM"},
                new EmpresaViewModel{ uf ="BA"},
                new EmpresaViewModel{ uf ="CE"},
                new EmpresaViewModel{ uf ="DF"},
                new EmpresaViewModel{ uf ="ES"},
                new EmpresaViewModel{ uf ="GO"},
                new EmpresaViewModel{ uf ="MA"},
                new EmpresaViewModel{ uf ="MT"},
                new EmpresaViewModel{ uf ="MS"},
                new EmpresaViewModel{ uf ="MG"},
                new EmpresaViewModel{ uf ="PA"},
                new EmpresaViewModel{ uf ="PB"},
                new EmpresaViewModel{ uf ="PR"},
                new EmpresaViewModel{ uf ="PE"},
                new EmpresaViewModel{ uf ="PI"},
                new EmpresaViewModel{ uf ="RJ"},
                new EmpresaViewModel{ uf ="RN"},
                new EmpresaViewModel{ uf ="RS"},
                new EmpresaViewModel{ uf ="RO"},
                new EmpresaViewModel{ uf ="RR"},
                new EmpresaViewModel{ uf ="SC"},
                new EmpresaViewModel{ uf ="SP"},
                new EmpresaViewModel{ uf ="SE"},
                new EmpresaViewModel{ uf ="TO"}
            };
        }





    }
}