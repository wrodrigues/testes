using FluentValidation;
using TSContaCorrente.Domain.DTOs;

namespace TSContaCorrente.Domain.Validators
{
    public class ContaValidator : AbstractValidator<ContaDTO>
    {
        public ContaValidator()
        {
            RuleFor(x => x.Agencia).NotNull().WithMessage("Número da agência não pode ser nula");
            RuleFor(x => x.Conta).NotNull().WithMessage("Número da conta não pode ser nula");

            RuleFor(x => x.Agencia).NotEmpty().WithMessage("Número da agência não pode ser vazia");
            RuleFor(x => x.Conta).NotEmpty().WithMessage("Número da conta não pode ser vazia");
        }
    }
}
