using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransacaoAPI.Models
{
    public class SolicitacaoAntecipacao
    {

        public int Id { get; internal set; }
        public DateTime DataSolicitacao { get; internal set; }
        public DateTime? DataAnaliseInicio { get; internal set; }
        public DateTime? DataAnaliseFim { get; internal set; }
        public string Status { get; internal set; }
        public string Resultado { get; internal set; }
        public int TransacaoId { get; internal set; }
        public double ValorTotalTransacao { get; internal set; }
        public double ValorTotalRepasse { get; internal set; }
        public Transacao Transacao { get; set; }
    }
}
