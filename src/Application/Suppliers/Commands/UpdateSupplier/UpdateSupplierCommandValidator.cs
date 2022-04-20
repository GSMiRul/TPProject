using FluentValidation;

namespace TPProject.Application.Suppliers.Commands.UpdateSupplier;

public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
{
    public UpdateSupplierCommandValidator()
    {
        RuleFor(v => v.SuplierName)
            .MaximumLength(200)
            .NotEmpty();
    }
}
