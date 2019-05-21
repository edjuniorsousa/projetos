using System.Data.Entity.ModelConfiguration;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Infra.Data.EntityConfig
{
    public class FormacaoConfiguration : EntityTypeConfiguration<Formacao>
    {
        public FormacaoConfiguration()
        {
            HasKey(c => c.FormacaoId);
            
            Property(c => c.Curso).IsRequired().HasMaxLength(150);
            
            Property(c => c.Status).IsRequired().HasMaxLength(150);
            
            Property(c => c.DataConclusao).IsRequired();
        }
    }
}
