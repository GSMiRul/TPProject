using TPProject.Application.Common.Exceptions;
using TPProject.Application.Common.Interfaces;
using TPProject.Domain.Entities;
using MediatR;

namespace TPProject.Application.Brands.Commands.UpdateBrand;

public class UpdateBrandCommand : IRequest
{
    public int Id { get; set; }

    public string? BrandName { get; set; }

    public string? ShortName { get; set; }

}

public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateBrandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Brands
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Brand), request.Id);
        }

        entity.BarandName = request.BrandName;
        entity.ShortName = request.ShortName;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
