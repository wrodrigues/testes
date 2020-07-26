using System;
using System.Collections.Generic;
using System.Text;

namespace App.Domain.Entities
{
    public class ContaCorrente
    {
        public int Id { get; set; }
        public List<Lancamento> Lancamentos { get; set; } = new List<Lancamento>();
        public string NumAgencia { get; set; }
        public string NumConta { get; set; }
    }
}
