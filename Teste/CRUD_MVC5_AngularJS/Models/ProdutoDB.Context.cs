﻿//------------------------------------------------------------------------------
// <auto-generated>
//    O código foi gerado a partir de um modelo.
//
//    Alterações manuais neste arquivo podem provocar comportamento inesperado no aplicativo.
//    Alterações manuais neste arquivo serão substituídas se o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace CRUD_MVC5_AngularJS.Models
{
    public partial class ProdutosEntities : DbContext
    {
        public ProdutosEntities()
            : base("name=ProdutosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Produto> Produtoes { get; set; }
    }
}