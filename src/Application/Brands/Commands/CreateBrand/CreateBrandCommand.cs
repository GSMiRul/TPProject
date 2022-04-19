using TPProject.Application.Common.Interfaces;
using TPProject.Domain.Entities;
using MediatR;

namespace TPProject.Application.Brands.Commands.CreateBrand;

public class CreateBrandCommand : IRequest<int>
{
    public int Id { get; set; }

    public string? BrandName { get; set; }
    public string? ShortName { get; set; }
}

public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateBrandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        var entity = new Brand
        {
            BarandName = request.BrandName,
            ShortName = request.ShortName,
        };

        _context.Brands.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
