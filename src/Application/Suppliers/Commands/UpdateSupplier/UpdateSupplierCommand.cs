using TPProject.Application.Common.Exceptions;
using TPProject.Application.Common.Interfaces;
using TPProject.Domain.Entities;
using MediatR;

namespace TPProject.Application.Suppliers.Commands.UpdateSupplier;

public class UpdateSupplierCommand : IRequest
{
    public int Id { get; set; }

    public string? SuplierName { get; set; }

    public string? Address { get; set; }
}

public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateSupplierCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Suppliers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Supplier), request.Id);
        }

        entity.Address = request.Address;
        entity.SuplierName = request.SuplierName;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
