using FluentValidation;
using TPProject.Application.Common.Interfaces;

namespace TPProject.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator(IApplicationDbContext context)
    {
        RuleFor(v => v.ProductName)
            .MaximumLength(200)
            .NotEmpty().WithMessage("Brand name should not be empty.");
    }
}
