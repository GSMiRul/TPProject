using TPProject.Application.Common.Interfaces;
using TPProject.Domain.Entities;
using MediatR;

namespace TPProject.Application.Suppliers.Commands.CreateSupplier;

public class CreateSupplierCommand : IRequest<int>
{
    public int Id { get; set; }

    public string? SuplierName { get; set; }

    public string? Address { get; set; }
}

public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSupplierCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
    {
        var entity = new Supplier
        {
            Id = request.Id,
            SuplierName = request.SuplierName,
            Address = request.Address
        };

        _context.Suppliers.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
