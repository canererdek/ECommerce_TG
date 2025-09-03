using FluentValidation;

namespace ECommerce_TG.Application.Products.Commands.AddProduct;

public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
{
    public AddProductCommandValidator()
    {
        RuleFor(r=>r.Name)
            .NotEmpty().WithMessage("Name is not empty")
            .NotNull().WithMessage("Name is required");
    }
}