using TPProject.Application.Common.Exceptions;
using TPProject.Application.Common.Interfaces;
using TPProject.Domain.Entities;
using TPProject.Domain.Enums;
using MediatR;

namespace TPProject.Application.InvoicesDetails.Commands.UpdateInvoiceDetail;

public class UpdateInvoiceDetailsCommand : IRequest
{
    public int Id { get; set; }
    public string? SerialNumber { get; set; }
    public decimal Cost { get; set; }

    public ProductState state { get; set; }
}

public class UpdateTodoItemDetailCommandHandler : IRequestHandler<UpdateInvoiceDetailsCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoItemDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateInvoiceDetailsCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.InvoiceDetails
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(InvoiceDetail), request.Id);
        }

        entity.Id = request.Id;
        entity.Cost = request.Cost;
        entity.SerialNumber = request.SerialNumber;
        entity.State = request.state;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
