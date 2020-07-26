using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class Lancamento
    {
        public int Id { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
        public DateTime DataLancamento { get; set; }
        public Decimal Valor { get; set; }
    }
}
