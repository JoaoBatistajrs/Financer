using FluentValidation;

namespace FinancialManager.Application.ApiModels.Validations
{
    public class CategoryModelValidator : AbstractValidator<CategoryModel>
    {
        public CategoryModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição precisa ser informada!");
        }
    }
}
