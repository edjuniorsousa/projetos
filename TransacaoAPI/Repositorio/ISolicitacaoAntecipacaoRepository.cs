using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransacaoAPI.Models;

namespace TransacaoAPI.Repositorio
{
    public interface ISolicitacaoAntecipacaoRepository
    {

        void Add(SolicitacaoAntecipacao solicitacao);
        IEnumerable<SolicitacaoAntecipacao> GetAll();
        SolicitacaoAntecipacao Find(int id);
        void Remove(int id);
        void Update(SolicitacaoAntecipacao solicitacao);
        IEnumerable<SolicitacaoAntecipacao> BuscaPorPeriodo(DateTime dataInicial, DateTime dataFinal);
    }
}
