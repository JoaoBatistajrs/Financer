using FluentValidation;

namespace FinancialManager.Application.ApiModels.Validations
{
    public class RegisterModelValidator : AbstractValidator<RegisterModelCreate>
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

            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Categoria precisa ser informada!");

            RuleFor(x => x.BankId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Banco precisa ser informado!");
        }
    }
}
