using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransacaoAPI.Models
{
    public class Taxa
    {
        public int Id { get; internal set; }
        public double ValorCobrado { get; internal set; }
        public Transacao Transacao { get; set; }
        public List<Transacao> Transacoes { get; set; }

    }
}
