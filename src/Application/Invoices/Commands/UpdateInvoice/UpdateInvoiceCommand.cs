using TPProject.Application.Common.Exceptions;
using TPProject.Application.Common.Interfaces;
using TPProject.Domain.Entities;
using MediatR;

namespace TPProject.Application.Invoices.Commands.UpdateInvoice;

public class UpdateInvoiceCommand : IRequest
{
    public int Id { get; set; }

    public int InvoiceNumber { get; set; }

}

public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateInvoiceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Invoices
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Invoice), request.Id);
        }

        entity.InvoiceNumber = request.InvoiceNumber;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
