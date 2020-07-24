using System;

namespace TSContaCorrente.Domain.Entidades
{
    public class Lancamento
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public int TipoLancamentoId { get; set; }
        public TipoLancamento TipoLancamento { get; set; }
        public Decimal Valor { get; set; }
        public Lancamento()
        {

        }
    }
}
