using System.Data.Entity.ModelConfiguration;
using ProtechAtividade_DDD.Domain.Entities;

namespace ProtechAtividade_DDD.Infra.Data.EntityConfig
{
    public class ExperienciaConfiguration : EntityTypeConfiguration<Experiencia>
    {
        public ExperienciaConfiguration()
        {
            HasKey(c => c.ExperienciaId);

            Property(c => c.Tecnologia).IsRequired().HasMaxLength(150);

            Property(c => c.TempoExperiencia).IsRequired();

            Property(c => c.DetalheExperiencia);
        }
    }
}
