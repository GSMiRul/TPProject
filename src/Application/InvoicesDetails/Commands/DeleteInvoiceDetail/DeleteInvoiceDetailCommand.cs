using TPProject.Application.Common.Exceptions;
using TPProject.Application.Common.Interfaces;
using TPProject.Domain.Entities;
using MediatR;

namespace TPProject.Application.InvoicesDetails.Commands.DeleteInvoiceDetail;

public class DeleteInvoiceDetailCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteInvoiceDetailCommandHandler : IRequestHandler<DeleteInvoiceDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteInvoiceDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteInvoiceDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.InvoiceDetails
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(InvoiceDetail), request.Id);
        }

        _context.InvoiceDetails.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
