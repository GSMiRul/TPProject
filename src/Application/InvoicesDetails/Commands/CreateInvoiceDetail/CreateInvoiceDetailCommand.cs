using TPProject.Application.Common.Interfaces;
using TPProject.Domain.Entities;
using MediatR;

namespace TPProject.Application.InvoicesDetails.Commands.CreateInvoiceDetail;

public class CreateInvoiceDetailCommand : IRequest<int>
{
    public int Id { get; set; }
    public string? SerialNumber { get; set; }
    public decimal Cost { get; set; }
}

public class CreateInvoiceDetailCommandHandler : IRequestHandler<CreateInvoiceDetailCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateInvoiceDetailCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateInvoiceDetailCommand request, CancellationToken cancellationToken)
    {
        var entity = new InvoiceDetail
        {
            Id = request.Id,
            SerialNumber = request.SerialNumber,
            Cost = request.Cost,
            Created = DateTime.Now,
            LastModified = DateTime.Now,
        };

        _context.InvoiceDetails.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
