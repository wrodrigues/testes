using TSContaCorrente.Domain.DTOs;

namespace TSContaCorrente.Domain.Servicos
{
    public interface IServicoTransferencia
    {
        void ProcessarTransferencia(TransferenciaDTO transferencia);
    }
}
