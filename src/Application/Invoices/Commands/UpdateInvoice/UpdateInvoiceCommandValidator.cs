using FluentValidation;

namespace TPProject.Application.Invoices.Commands.UpdateInvoice;

public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
{
    public UpdateInvoiceCommandValidator()
    {
        RuleFor(v => v.InvoiceNumber)
            .GreaterThan(0)
            .NotEmpty();
    }
}
