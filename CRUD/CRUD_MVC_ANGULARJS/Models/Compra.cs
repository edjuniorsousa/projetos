//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_MVC_ANGULARJS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Compra
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public Nullable<int> idProduto { get; set; }
        public Nullable<int> quantidade { get; set; }
        public Nullable<System.DateTime> dataVenda { get; set; }
        public Nullable<decimal> valorTotal { get; set; }
    }
}