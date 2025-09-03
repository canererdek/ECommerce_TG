using FluentValidation;

namespace ECommerce_TG.Application.Categories.Command.AddCategory;

public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
{
    public AddCategoryCommandValidator()
    {
        RuleFor(r=>r.CategoryName)
            .NotEmpty().WithMessage("CategoryName is not empty")
            .NotNull().WithMessage("CategoryName is required");
    }
}