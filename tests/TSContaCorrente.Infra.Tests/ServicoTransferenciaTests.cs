using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TSContaCorrente.Domain.DTOs;
using TSContaCorrente.Domain.Validators;
using TSContaCorrente.Infra.Data;
using TSContaCorrente.Infra.Extensions;
using TSContaCorrente.Infra.Servicos;
using Xunit;

namespace TSContaCorrente.Infra.Tests
{
    public class ServicoTransferenciaTests
    {
        protected IValidator<ContaDTO> ContaValidator { get; set; }
        protected IValidator<TransferenciaDTO> TransferenciaValidator { get; set; }
        protected AppDbContext AppDbContext { get; set; }
        protected string AgenciaOrigem { get; set; }
        protected string ContaOrigem { get; set; }
        protected string AgenciaDestino { get; set; }
        protected string ContaDestino { get; set; }
        protected decimal ValorTransferencia { get; set; }
        protected ServicoTransferencia ServicoTransferencia { get; set; }
        public ServicoTransferenciaTests()
        {
            ContaValidator = new ContaValidator();

            TransferenciaValidator = new TransferenciaValidator();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            
            optionsBuilder.UseInMemoryDatabase("AppBd");

            AppDbContext = new AppDbContext(optionsBuilder.Options);

            AppDbContext.Seed();

            AgenciaOrigem = "1010";
            ContaOrigem = "1010-1";

            AgenciaDestino = "2020";
            ContaDestino = "2020-2";

            ValorTransferencia = 10m;
        }

        [Fact]
        public void Deve_Transferir_Com_Sucesso()
        {
            //arrange
            ServicoTransferencia = new ServicoTransferencia(ContaValidator, TransferenciaValidator, AppDbContext);

            var contaOrigem = new ContaDTO(AgenciaOrigem, ContaOrigem);

            var contaDestino = new ContaDTO(AgenciaDestino, ContaDestino);

            var dtoTranferencia = new TransferenciaDTO(contaOrigem, contaDestino, ValorTransferencia);

            //action
            ServicoTransferencia.ProcessarTransferencia(dtoTranferencia);

            //assert

            Assert.Empty(dtoTranferencia.Errors);

            Assert.Empty(dtoTranferencia.ContaOrigem.Errors);

            Assert.Empty(dtoTranferencia.ContaDestino.Errors);
        }

        [Fact]
        public void Deve_Validar_Transferencia_Com_Sucesso()
        {
            //arrange
            ServicoTransferencia = new ServicoTransferencia(ContaValidator, TransferenciaValidator, AppDbContext);

            var contaOrigem = new ContaDTO(AgenciaOrigem, ContaOrigem);

            var contaDestino = new ContaDTO(AgenciaDestino, ContaDestino);

            var dtoTranferencia = new TransferenciaDTO(contaOrigem, contaDestino, ValorTransferencia);

            //action
            var result = ServicoTransferencia.Validate(dtoTranferencia);

            //assert

            Assert.Empty(dtoTranferencia.Errors);

            Assert.Empty(dtoTranferencia.ContaOrigem.Errors);

            Assert.Empty(dtoTranferencia.ContaDestino.Errors);

            Assert.True(result);
        }

        [Fact]
        public void Deve_Acusar_Erro_Conta_Origem()
        {
            //arrange
            ServicoTransferencia = new ServicoTransferencia(ContaValidator, TransferenciaValidator, AppDbContext);

            var contaOrigem = new ContaDTO(string.Empty, string.Empty);

            var contaDestino = new ContaDTO(AgenciaDestino, ContaDestino);

            var dtoTranferencia = new TransferenciaDTO(contaOrigem, contaDestino, ValorTransferencia);

            //action
            var result = ServicoTransferencia.Validate(dtoTranferencia);

            //assert

            Assert.False(result);

            Assert.Empty(dtoTranferencia.Errors);

            Assert.NotEmpty(dtoTranferencia.ContaOrigem.Errors);

            Assert.Empty(dtoTranferencia.ContaDestino.Errors);            
        }

        [Fact]
        public void Deve_Acusar_Erro_Conta_Destino()
        {
            //arrange
            ServicoTransferencia = new ServicoTransferencia(ContaValidator, TransferenciaValidator, AppDbContext);

            var contaOrigem = new ContaDTO(AgenciaOrigem, ContaOrigem);

            var contaDestino = new ContaDTO(string.Empty, string.Empty);

            var dtoTranferencia = new TransferenciaDTO(contaOrigem, contaDestino, ValorTransferencia);

            //action
            var result = ServicoTransferencia.Validate(dtoTranferencia);

            //assert

            Assert.False(result);

            Assert.Empty(dtoTranferencia.Errors);

            Assert.Empty(dtoTranferencia.ContaOrigem.Errors);

            Assert.NotEmpty(dtoTranferencia.ContaDestino.Errors);
        }

        [Fact]
        public void Deve_Acusar_Erro_Valor_Transferencia()
        {
            //arrange
            ServicoTransferencia = new ServicoTransferencia(ContaValidator, TransferenciaValidator, AppDbContext);

            var contaOrigem = new ContaDTO(AgenciaOrigem, ContaOrigem);

            var contaDestino = new ContaDTO(AgenciaDestino, ContaDestino);

            var dtoTranferencia = new TransferenciaDTO(contaOrigem, contaDestino, 0);

            //action
            var result = ServicoTransferencia.Validate(dtoTranferencia);

            //assert

            Assert.False(result);

            Assert.NotEmpty(dtoTranferencia.Errors);

            Assert.Empty(dtoTranferencia.ContaOrigem.Errors);

            Assert.Empty(dtoTranferencia.ContaDestino.Errors);
        }

        [Fact]
        public void Deve_Acusar_Erro_Valor_Transferencia_Com_Saldo_Insuficiente()
        {
            //arrange
            ServicoTransferencia = new ServicoTransferencia(ContaValidator, TransferenciaValidator, AppDbContext);

            var contaOrigem = new ContaDTO(AgenciaOrigem, ContaOrigem);

            var contaDestino = new ContaDTO(AgenciaDestino, ContaDestino);

            var dtoTranferencia = new TransferenciaDTO(contaOrigem, contaDestino, 2000.0m);

            //action
            ServicoTransferencia.ProcessarTransferencia(dtoTranferencia);

            //assert            

            Assert.NotEmpty(dtoTranferencia.Errors);

            Assert.Empty(dtoTranferencia.ContaOrigem.Errors);

            Assert.Empty(dtoTranferencia.ContaDestino.Errors);
        }
    }
}
