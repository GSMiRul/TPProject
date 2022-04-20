using FluentValidation;

namespace TPProject.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(v => v.ProductName)
            .MaximumLength(200)
            .NotEmpty();
    }
}
