using FluentValidation;

namespace FinancialManager.Application.DTOs.Validations
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição precisa ser informada!");

            RuleFor(x => x.Amount)
                .NotEmpty()
                .NotNull()
                .WithMessage("Total precisa ser informado!");

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Categoria precisa ser informada!");
        }
    }
}
