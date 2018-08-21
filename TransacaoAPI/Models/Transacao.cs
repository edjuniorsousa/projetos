using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TransacaoAPI.Models
{
    public class Transacao
    {
        public int Id { get; internal set; }
        public DateTime DataTransacao { get; internal set; }
        public DateTime? DataRepasse { get; internal set; }
        public string Confirmacao { get; internal set; }
        public double ValorTransacao { get; internal set; }
        public double? ValorRepasse { get; internal set; }
        public int NumeroParcelas { get; internal set; }
        public int IdTaxa { get; set; }
        public Taxa taxa { get; set; }
        
        //public SolicitacaoAntecipacao SolicitacaoAntecipao { get; set; }
        public IList<SolicitacaoAntecipacao> SolicitacoesAntecipacao { get; set; }

        [NotMapped]
        public double ValorSolicitacaoAntecipacao { get; set; }

        public double CalculaValorSolicitacaoAntecipacao(double? valorRepasse, int numeroParcelas)
        {
            var valorParcela = ((double)valorRepasse / numeroParcelas);
            return Math.Round((valorParcela * 0.038) * numeroParcelas, 2);
        }
    }
}
