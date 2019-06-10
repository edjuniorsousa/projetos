
using Fornecedores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.IO;
using System.Linq;
using System.Text;

namespace Fornecedores.Infra.Data.EntityConfig
{
    public class EmpresaConfiguration : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfiguration()
        {
            HasKey(c => c.id);

            Property(c => c.nomeFantasia).IsRequired();

            Property(c => c.cnpj).IsRequired().HasMaxLength(14);

            Property(c => c.uf).IsRequired().HasMaxLength(2);

        }
    }
}