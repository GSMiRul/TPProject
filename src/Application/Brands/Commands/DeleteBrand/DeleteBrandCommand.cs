using TPProject.Application.Common.Exceptions;
using TPProject.Application.Common.Interfaces;
using TPProject.Domain.Entities;
using TPProject.Domain.Events;
using MediatR;

namespace TPProject.Application.Brands.Commands.DeleteBrand;

public class DeleteBrandCommand : IRequest
{
    public int Id { get; set; }
}

public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteBrandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Brands
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Brand), request.Id);
        }

        _context.Brands.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
