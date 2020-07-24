using System.Collections.Generic;

namespace TSContaCorrente.Domain.Entidades
{
    public class TipoLancamento
    {
        public int Id { get; set; }

        public string Descricao { get; set; }
        public virtual ICollection<Lancamento> Lancamentos { get; set; }

        public TipoLancamento()
        {
            Lancamentos = new List<Lancamento>();
        }
    }
}
