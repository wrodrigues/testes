using System;
using System.Collections.Generic;

namespace TSContaCorrente.Domain.Entidades
{
    public class ContaCorrente
    {
        public int Id { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public Decimal Saldo { get; set; }
        public virtual ICollection<Lancamento> Lancamentos { get; set; }
        public ContaCorrente()
        {
            Lancamentos = new List<Lancamento>();
        }
    }
}
