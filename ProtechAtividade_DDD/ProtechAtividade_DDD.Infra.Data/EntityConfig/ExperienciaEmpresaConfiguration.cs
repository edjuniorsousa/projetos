using System.Data.Entity.ModelConfiguration;
using ProtechAtividade_DDD.Domain.Entities;

namespace ProtechAtividade_DDD.Infra.Data.EntityConfig
{
    public class ExperienciaEmpresaConfiguration : EntityTypeConfiguration<ExperienciaEmpresa>
    {
        public ExperienciaEmpresaConfiguration()
        {
            HasKey(c => c.ExperienciaEmpresaId);

            Property(c => c.Empresa).IsRequired().HasMaxLength(150);

            Property(c => c.Cargo).IsRequired().HasMaxLength(150);

            Property(c => c.DataInicio).IsRequired();

            Property(c => c.DataFim).IsRequired();

            Property(c => c.DetalheExperiencia);
        }
    }
}
