using System;

namespace TSContaCorrente.Api.Models.Request
{
    public class TransferenciaRequest
    {
        public ContaRequest ContaOrigem { get; set; }
        public ContaRequest ContaDestino { get; set; }
        public Decimal Valor { get; set; }
        public TransferenciaRequest()
        {

        }
    }
}
