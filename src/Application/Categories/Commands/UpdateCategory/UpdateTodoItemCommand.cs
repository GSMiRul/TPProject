using TPProject.Application.Common.Exceptions;
using TPProject.Application.Common.Interfaces;
using TPProject.Domain.Entities;
using MediatR;

namespace TPProject.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Category), request.Id);
        }

        entity.Name = request.Name;
        entity.Description = request.Description;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
