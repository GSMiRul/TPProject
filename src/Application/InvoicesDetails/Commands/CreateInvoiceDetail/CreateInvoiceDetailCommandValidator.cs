using FluentValidation;

namespace TPProject.Application.InvoicesDetails.Commands.CreateInvoiceDetail;

public class CreateInvoiceDetailCommandValidator : AbstractValidator<CreateInvoiceDetailCommand>
{
    public CreateInvoiceDetailCommandValidator()
    {
        RuleFor(v => v.SerialNumber)
            .MaximumLength(200)
            .NotEmpty();
    }
}
