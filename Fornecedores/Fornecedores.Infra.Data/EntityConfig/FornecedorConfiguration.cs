using Fornecedores.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornecedores.Infra.Data.EntityConfig
{
    public class FornecedorConfiguration : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfiguration()
        {
            HasKey(c => c.id);

            Property(c => c.nome).IsRequired();

            Property(c => c.cnpjOuCpf).IsRequired().HasMaxLength(14);

            HasRequired(p => p.Empresa)
                .WithMany()
                .HasForeignKey(p => p.idEmpresa);

            Property(c => c.dataCadastro);

            Property(c => c.dataNasc);

            Property(c => c.telefone).IsRequired().HasMaxLength(11);

            Property(c => c.rg).HasMaxLength(9);

            Property(c => c.tipo).IsRequired().HasMaxLength(2);

        }
    }
}
