using FluentValidation;

namespace FinancialManager.Application.ApiModels.Validations
{
    public class BankModelValidator : AbstractValidator<BankModel>
    {
        public BankModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome precisa ser informado!");
        }
    }
}
