using FluentValidation;

namespace FinancialManager.Application.DTOs.Validations
{
    public class BankDtoValidator : AbstractValidator<BankDto>
    {
        public BankDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome precisa ser informada!");
        }
    }
}
