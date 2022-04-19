using TPProject.Application.Common.Interfaces;
using TPProject.Domain.Entities;
using MediatR;

namespace TPProject.Application.Invoices.Commands.CreateInvoice;

public class CreateInvoiceCommand : IRequest<int>
{
    public int Id { get; set; }

    public int InvoiceNumber { get; set; }
}

public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateInvoiceCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        var entity = new Invoice
        {
            Id = request.Id,
            InvoiceNumber = request.InvoiceNumber,
            Created = DateTime.Now,
            LastModified = DateTime.Now,
        };

        _context.Invoices.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
