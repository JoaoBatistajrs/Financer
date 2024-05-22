using FluentValidation;

namespace FinancialManager.Application.ApiModels.Validations
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição precisa ser informada!");

            RuleFor(x => x.Amount)
                .GreaterThan(0)
                .WithMessage("Valor precisa ser maior que zero!");

            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Categoria precisa ser informada!");

            RuleFor(x => x.BankName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Banco precisa ser informado!");
        }
    }
}
