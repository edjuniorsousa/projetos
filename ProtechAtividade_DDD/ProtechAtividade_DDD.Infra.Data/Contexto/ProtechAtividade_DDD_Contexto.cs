using ProtechAtividade_DDD.Domain.Entities;
using ProtechAtividade_DDD.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtechAtividade_DDD.Infra.Data.Contexto
{
    public class ProtechAtividade_DDD_Contexto : DbContext
    {
        public ProtechAtividade_DDD_Contexto()
            : base("ProtechAtividade_DDD")
        {

        }

        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<ExperienciaEmpresa> ExperienciasEmpresa { get; set; }
        public DbSet<Formacao> Formacoes { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

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
