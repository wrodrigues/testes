namespace TSContaCorrente.Api.Models.Response
{
    public class ResultadoResponse
    {
        public TransferenciaResponse Transferencia { get; set; }
        public ResultadoResponse(TransferenciaResponse transferencia)
        {
            Transferencia = transferencia;
        }
    }
}
