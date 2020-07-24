using TSContaCorrente.Domain.DTOs;

namespace TSContaCorrente.Api.Models.Response
{
    public class ContaResponse : BaseResponse
    {
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public decimal Saldo { get; set; }

        public ContaResponse(ContaDTO dto)
        {
            Agencia = dto.Agencia;

            Conta = dto.Conta;

            Saldo = dto.Saldo;

            Errors = dto.Errors;
        }
    }
}
