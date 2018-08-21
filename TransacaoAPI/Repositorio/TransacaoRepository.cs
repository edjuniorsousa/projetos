using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransacaoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TransacaoAPI.Repositorio
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly TransacaoDbContext _contexto;

        public TransacaoRepository()
        {
        }

        public TransacaoRepository(TransacaoDbContext ctx)
        {
            _contexto = ctx;
        }
        public void Add(Transacao trans)
        {
            throw new NotImplementedException();
        }

        public Transacao Find(int id)
        {
            return _contexto.Transacao.Include(p => p.SolicitacoesAntecipacao).Where(p => p.Id==id).FirstOrDefault();
        }

        public Transacao Busca(int id)
        {
            return _contexto.Transacao.FirstOrDefault(p => p.Id==id);
        }

        public IEnumerable<Transacao> GetAll()

        {
            return _contexto.Transacao.ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Transacao trans)
        {
            _contexto.Transacao.Update(trans);
            _contexto.SaveChanges();
        }
    }
}
