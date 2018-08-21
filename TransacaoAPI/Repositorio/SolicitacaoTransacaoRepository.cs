using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransacaoAPI.Models;

namespace TransacaoAPI.Repositorio
{
    public class SolicitacaoTransacaoRepository : ISolicitacaoAntecipacaoRepository
    {
        private readonly TransacaoDbContext _contexto;
        public SolicitacaoTransacaoRepository(TransacaoDbContext ctx)
        {
            _contexto = ctx;
        }
        public void Add(SolicitacaoAntecipacao solicitacao)
        {
            _contexto.SolicitacaoAntecipacao.Add(solicitacao);
            _contexto.SaveChanges();
        }

        public SolicitacaoAntecipacao Find(int id)
        {
            return _contexto.SolicitacaoAntecipacao.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<SolicitacaoAntecipacao> GetAll()
        {
            return _contexto.SolicitacaoAntecipacao.ToList();
        }

        public void Remove(int id)
        {
            var entity = _contexto.SolicitacaoAntecipacao.FirstOrDefault(u => u.Id == id);
            _contexto.SolicitacaoAntecipacao.Remove(entity);
            _contexto.SaveChanges();
        }

        public void Update(SolicitacaoAntecipacao solicitacao)
        {
            _contexto.SolicitacaoAntecipacao.Update(solicitacao);
            _contexto.SaveChanges();
        }
        public IEnumerable<SolicitacaoAntecipacao> BuscaPorPeriodo(DateTime dataInicial, DateTime dataFinal)
        {
            return _contexto.SolicitacaoAntecipacao.ToList().Where(s => s.DataSolicitacao >= dataInicial && s.DataSolicitacao < dataFinal).ToList();
        }

    }
}
