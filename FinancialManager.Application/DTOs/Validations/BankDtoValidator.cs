using FluentValidation;

namespace FinancialManager.Application.DTOs.Validations
{
    public class BankDtoValidator : AbstractValidator<CategoryDto>
    {
        public BankDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome precisa ser informada!");

            RuleFor(x => x.AccountType)
                .NotEmpty()
                .NotNull()
                .WithMessage("Tipo da conta precisa ser informado!");
        }
    }
}
