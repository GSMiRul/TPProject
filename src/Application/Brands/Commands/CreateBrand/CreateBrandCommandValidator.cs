using FluentValidation;

namespace TPProject.Application.Brands.Commands.CreateBrand;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(v => v.BrandName)
            .MaximumLength(200)
            .NotEmpty();
        RuleFor(v => v.ShortName)
            .MaximumLength(100)
            .NotEmpty();
    }
}
