using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fornecedores.MVC.ViewModels
{
    public class FornecedorViewModel
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Informe o CNPJ")]
        [MaxLength(14, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("CNPJ/CPF")]
        public string cnpjOuCpf { get; set; }

        public int idEmpresa { get; set; }

        [Required(ErrorMessage = "Informe o tipo")]
        [DisplayName("Tipo")]
        public string tipo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime dataCadastro { get; set; }

        [MaxLength(11, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Telefone")]
        public string telefone { get; set; }

        [MaxLength(9, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("RG")]
        public string rg { get; set; }

        [DisplayName("Data Nascimento")]
        public DateTime dataNasc { get; set; }

        public virtual EmpresaViewModel Empresa { get; set; }
    }
}