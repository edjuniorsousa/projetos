using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjetoDDD.Infra.Data.Contexto
{
    public class ProjetoDDDContext : DbContext
    {
        public ProjetoDDDContext() : base("ProjetoDDD")
        {

        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Experiencia> Experiencia { get; set; }
        public DbSet<ExperienciaEmpresa> ExperienciaEmpresa { get; set; }
        public DbSet<Formacao> Formacao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties().Where(p => p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new PessoaConfiguration());
            modelBuilder.Configurations.Add(new ExperienciaConfiguration());
            modelBuilder.Configurations.Add(new ExperienciaEmpresaConfiguration());
            modelBuilder.Configurations.Add(new FormacaoConfiguration());
        }
    }

}
