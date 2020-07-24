using System;
using System.Linq;
using FluentValidation;
using TSContaCorrente.Domain;
using TSContaCorrente.Domain.DTOs;
using TSContaCorrente.Domain.Entidades;
using TSContaCorrente.Domain.Servicos;
using TSContaCorrente.Infra.Data;

namespace TSContaCorrente.Infra.Servicos
{
    public class ServicoTransferencia : IServicoTransferencia
    {
        private readonly IValidator<ContaDTO> ContaValidator;
        private readonly IValidator<TransferenciaDTO> TransferenciaValidator;
        private readonly AppDbContext dbContext;

        public ServicoTransferencia(IValidator<ContaDTO> contaValidator, IValidator<TransferenciaDTO> transferenciaValidator, AppDbContext dbContext)
        {
            this.ContaValidator = contaValidator;
            this.TransferenciaValidator = transferenciaValidator;
            this.dbContext = dbContext;
        }

        public void ProcessarTransferencia(TransferenciaDTO transferencia)
        {
            bool dtoValido = this.Validate(transferencia);

            if (dtoValido)
            {
                //validando os dados da conta de origem
                var contaOrigem = (from item in this.dbContext.Contas
                                   where item.Agencia == transferencia.ContaOrigem.Agencia
                                   && item.Conta == transferencia.ContaOrigem.Conta
                                   select item).FirstOrDefault();

                if (contaOrigem == null)
                {
                    transferencia.ContaOrigem.Errors.Add("Agencia/Conta de origem não localizado");
                    return;
                }

                //validando os dados da conta de Destino
                var contaDestino = (from item in this.dbContext.Contas
                                    where item.Agencia == transferencia.ContaDestino.Agencia
                                    && item.Conta == transferencia.ContaDestino.Conta
                                    select item).FirstOrDefault();

                if (contaDestino == null)
                {
                    transferencia.ContaDestino.Errors.Add("Agencia/Conta de Destino não localizado");
                    return;
                }

                //validando saldo de origem (operação > que saldo de origem, não pode executar transferência)
                if (transferencia.Valor > contaOrigem.Saldo)
                {
                    transferencia.Errors.Add($"Saldo ({contaOrigem.Saldo}) insuficiente para realizar a transferência {transferencia.Valor}");
                }
                else
                {
                    //  reduz saldo da conta de origem
                    contaOrigem.Saldo = contaOrigem.Saldo - transferencia.Valor;

                    //  incrementa saldo na conta de destino
                    contaDestino.Saldo = contaDestino.Saldo + transferencia.Valor;

                    //  adiciona lançamento na conta de origem
                    var debito = new Lancamento
                    {
                        Data = DateTime.Now,
                        TipoLancamentoId = (int)EnumTipoLancamento.Debito,
                        Valor = transferencia.Valor,
                        ContaCorrenteId = contaOrigem.Id
                    };

                    contaOrigem.Lancamentos.Add(debito);

                    //  lançamento de credito
                    var credito = new Lancamento
                    {
                        Data = DateTime.Now,
                        TipoLancamentoId = (int)EnumTipoLancamento.Credito,
                        Valor = transferencia.Valor,
                        ContaCorrenteId = contaDestino.Id
                    };

                    //  adiciona lançamento na conta de destino
                    contaDestino.Lancamentos.Add(credito);

                    dbContext.SaveChanges();

                    transferencia.ContaDestino.Saldo = contaDestino.Saldo;

                    transferencia.ContaOrigem.Saldo = contaOrigem.Saldo;
                }
            }
        }

        public bool Validate(TransferenciaDTO transferencia)
        {
            bool contaOrigemValida = false;

            var validacaoOrigem = ContaValidator.Validate(transferencia.ContaOrigem);

            if (validacaoOrigem != null)
            {
                contaOrigemValida = validacaoOrigem.IsValid;

                transferencia.ContaOrigem.Errors = validacaoOrigem.Errors.Select(x => x.ErrorMessage).ToList();
            }

            bool contaDestinoValida = false;

            var validacaoDestino = ContaValidator.Validate(transferencia.ContaDestino);

            if (validacaoDestino != null)
            {
                contaDestinoValida = validacaoDestino.IsValid;

                transferencia.ContaDestino.Errors = validacaoDestino.Errors.Select(x => x.ErrorMessage).ToList();
            }

            bool contaTransferenciaValida = false;

            var validacaoTransferencia = TransferenciaValidator.Validate(transferencia);

            if (validacaoTransferencia != null)
            {
                contaTransferenciaValida = validacaoTransferencia.IsValid;

                transferencia.Errors = validacaoTransferencia.Errors.Select(x => x.ErrorMessage).ToList();
            }

            return (contaOrigemValida == true) && (contaDestinoValida == true) && (contaTransferenciaValida == true);
        }
    }
}
