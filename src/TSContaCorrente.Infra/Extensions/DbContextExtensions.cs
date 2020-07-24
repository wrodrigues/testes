using TSContaCorrente.Domain.Entidades;
using TSContaCorrente.Infra.Data;

namespace TSContaCorrente.Infra.Extensions
{
    public static class DbContextExtensions
    {
        public static void Seed(this AppDbContext context)
        {
            //Tipos de lançamento
            context.TipoLancamento.Add(new TipoLancamento { Descricao = "Débito" });
            context.TipoLancamento.Add(new TipoLancamento { Descricao = "Crédito" });

            //Contas válidas (para testes)
            context.Contas.Add(new ContaCorrente { Agencia = "1010", Conta = "1010-1", Saldo = 150.00m });
            context.Contas.Add(new ContaCorrente { Agencia = "2020", Conta = "2020-2", Saldo = 100.00m });

            context.SaveChanges();
        }
    }
}
