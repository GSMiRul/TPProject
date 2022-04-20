using FluentValidation;

namespace TPProject.Application.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
{
    public CreateSupplierCommandValidator()
    {
        RuleFor(v => v.SuplierName)
            .MaximumLength(200)
            .NotEmpty();
    }
}
