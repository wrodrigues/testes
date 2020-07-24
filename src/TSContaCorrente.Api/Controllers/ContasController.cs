using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TSContaCorrente.Api.Models.Request;
using TSContaCorrente.Api.Models.Response;
using TSContaCorrente.Domain.DTOs;
using TSContaCorrente.Domain.Servicos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TSContaCorrente.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IServicoTransferencia servicoTransferencia;
        public ContasController(IServicoTransferencia servicoTransferencia)
        {
            this.servicoTransferencia = servicoTransferencia;
        }

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Post([FromBody] TransferenciaRequest transferencia)
        {
            var contaOrigem = new ContaDTO(transferencia.ContaOrigem.Agencia, transferencia.ContaOrigem.Conta);

            var contaDestino = new ContaDTO(transferencia.ContaDestino.Agencia, transferencia.ContaDestino.Conta);

            var dtoTransferencia = new TransferenciaDTO(contaOrigem, contaDestino, transferencia.Valor);

            servicoTransferencia.ProcessarTransferencia(dtoTransferencia);

            var response = new ResultadoResponse(new TransferenciaResponse(dtoTransferencia));

            return Ok(response);
        }
    }
}
