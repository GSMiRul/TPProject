using TPProject.Application.Common.Exceptions;
using TPProject.Application.Common.Interfaces;
using TPProject.Domain.Entities;
using MediatR;

namespace TPProject.Application.InvoicesDetails.Commands.UpdateInvoiceDetail;

public class UpdateInvoiceDetailCommand : IRequest
{
    public int Id { get; set; }
    public string? SerialNumber { get; set; }
    public decimal Cost { get; set; }
}

public class UpdateInvoiceDetailCommandHandler : IRequestHandler<UpdateInvoiceDetailCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateInvoiceDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateInvoiceDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.InvoiceDetails
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(InvoiceDetail), request.Id);
        }

        entity.SerialNumber = request.SerialNumber;
        entity.Cost = request.Cost;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
