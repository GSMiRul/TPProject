using FluentValidation;

namespace TPProject.Application.Invoices.Commands.CreateInvoice;

public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceCommandValidator()
    {
        RuleFor(v => v.InvoiceNumber)
            .GreaterThan(0)
            .NotEmpty();
    }
}
