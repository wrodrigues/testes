using System;

namespace TSContaCorrente.Domain.DTOs
{
    public class TransferenciaDTO : BaseDTO
    {
        public ContaDTO ContaOrigem { get; set; }
        public ContaDTO ContaDestino { get; set; }
        public Decimal Valor { get; set; }

        public TransferenciaDTO(ContaDTO contaOrigem, ContaDTO contaDestino, Decimal valor)
        {
            ContaOrigem = contaOrigem;

            ContaDestino = contaDestino;

            Valor = valor;
        }
    }
}
