using System;
using TSContaCorrente.Domain.DTOs;

namespace TSContaCorrente.Api.Models.Response
{
    public class TransferenciaResponse : BaseResponse
    {
        public ContaResponse ContaOrigem { get; set; }
        public ContaResponse ContaDestino { get; set; }
        public Decimal Valor { get; set; }
        public TransferenciaResponse(TransferenciaDTO dtoTransferencia)
        {
            ContaOrigem = new ContaResponse(dtoTransferencia.ContaOrigem);

            ContaDestino = new ContaResponse(dtoTransferencia.ContaDestino);

            Valor = dtoTransferencia.Valor;

            Errors = dtoTransferencia.Errors;
        }
    }
}
