using System.Data.Entity.ModelConfiguration;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Infra.Data.EntityConfig
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
