namespace TSContaCorrente.Domain.DTOs
{
    public class ContaDTO : BaseDTO
    {
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public decimal Saldo { get; set; }
        public ContaDTO(string agencia, string conta, decimal saldo = 0)
        {
            Agencia = agencia;
            Conta = conta;
            Saldo = saldo;
        }
    }
}
