using FluentValidation;
using TSContaCorrente.Api.Models.Request;

namespace TSContaCorrente.Api.Validators
{
    public class TransferenciaRequestValidator : AbstractValidator<TransferenciaRequest>
    {
        public TransferenciaRequestValidator()
        {
            RuleFor(x => x.ContaDestino).NotNull().WithMessage("Conta de destino não pode ser nula");
            RuleFor(x => x.ContaOrigem).NotNull().WithMessage("Conta de origem não pode ser nula");

            RuleFor(x => x.Valor).NotNull().WithMessage("O valor não pode ser nulo");
            RuleFor(x => x.Valor).NotEmpty().WithMessage("O valor não pode ser vazio");
            RuleFor(x => x.Valor).NotEqual(0).WithMessage("O valor deve ser superior a zero");
        }
    }
}
