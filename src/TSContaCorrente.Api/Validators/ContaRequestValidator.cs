using FluentValidation;
using TSContaCorrente.Api.Models.Request;

namespace TSContaCorrente.Api.Validators
{
    public class ContaRequestValidator : AbstractValidator<ContaRequest>
    {
        public ContaRequestValidator()
        {
            RuleFor(x => x.Agencia).NotNull().WithMessage("Número da agência não pode ser nula");
            RuleFor(x => x.Conta).NotNull().WithMessage("Número da conta não pode ser nula");

            RuleFor(x => x.Agencia).NotEmpty().WithMessage("Número da agência não pode ser vazia");
            RuleFor(x => x.Conta).NotEmpty().WithMessage("Número da conta não pode ser vazia");
        }
    }
}
