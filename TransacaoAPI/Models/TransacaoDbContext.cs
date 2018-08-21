using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransacaoAPI.Models
{
    public class TransacaoDbContext : DbContext
    {
        public TransacaoDbContext(DbContextOptions<TransacaoDbContext> options) : base(options)
        { }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<SolicitacaoAntecipacao> SolicitacaoAntecipacao { get; set; }
        public DbSet<Taxa> Taxa { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SolicitacaoAntecipacao>()
                .HasOne(s => s.Transacao)
                .WithMany(t => t.SolicitacoesAntecipacao)
                .HasForeignKey(s => s.TransacaoId);

            modelBuilder
                .Entity<Transacao>()
                .HasOne(s => s.taxa)
                .WithMany(t => t.Transacoes)
                .HasForeignKey(s => s.IdTaxa);
        }
    }
}
