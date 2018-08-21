using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransacaoAPI.Models;

namespace TransacaoAPI.Repositorio
{
    public interface ITransacaoRepository
    {
        void Add(Transacao trans);
        IEnumerable<Transacao> GetAll();
        Transacao Find(int id);
        void Remove(int id);
        void Update(Transacao trans);
    }
}
