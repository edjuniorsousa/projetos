using System.Data.Entity.ModelConfiguration;
using ProtechAtividade_DDD.Domain.Entities;

namespace ProtechAtividade_DDD.Infra.Data.EntityConfig
{
    public class PessoaConfiguration : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfiguration()
        {
            HasKey(c => c.PessoaId);

            Property(c => c.Nome).IsRequired().HasMaxLength(150);

            Property(c => c.DataNascimento).IsRequired();

            Property(c => c.ExperienciaTotal).IsRequired();

            HasMany(p => p.Formacao).WithRequired(p => p.Pessoa).HasForeignKey(p => p.PessoaId);

            HasMany(p => p.Experiencia).WithRequired(p => p.Pessoa).HasForeignKey(p => p.PessoaId);

            HasMany(p => p.ExperienciaEmpresas).WithRequired(p => p.Pessoa).HasForeignKey(p => p.PessoaId);
        }
    }
}
