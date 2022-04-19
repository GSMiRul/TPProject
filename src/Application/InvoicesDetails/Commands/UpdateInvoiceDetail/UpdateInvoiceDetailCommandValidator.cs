using FluentValidation;

namespace TPProject.Application.InvoicesDetails.Commands.UpdateInvoiceDetail;

public class UpdateInvoiceDetailCommandValidator : AbstractValidator<UpdateInvoiceDetailCommand>
{
    public UpdateInvoiceDetailCommandValidator()
    {
        RuleFor(v => v.SerialNumber)
            .MaximumLength(200)
            .NotEmpty();
    }
}
