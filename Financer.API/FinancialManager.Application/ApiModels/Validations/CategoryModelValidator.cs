using FluentValidation;

namespace FinancialManager.Application.DTOs.Validations
{
    public class CategoryDtoValidator : AbstractValidator<CategoryModel>
    {
        public CategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição precisa ser informada!");
        }
    }
}
