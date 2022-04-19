using AutoMapper;
using AutoMapper.QueryableExtensions;
using TPProject.Application.Common.Interfaces;
using TPProject.Application.Common.Mappings;
using TPProject.Application.Common.Models;
using MediatR;

namespace TPProject.Application.Categories.Queries.GetCategoriesWithPagination;

public class GetCategoriesWithPaginationQuery : IRequest<PaginatedList<CategoryBriefDto>>
{
    public int Id { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetCategoriesWithPaginationQueryHandler : IRequestHandler<GetCategoriesWithPaginationQuery, PaginatedList<CategoryBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoriesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CategoryBriefDto>> Handle(GetCategoriesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Categories
            .Where(x => x.Id == request.Id)
            .OrderBy(x => x.Name)
            .ProjectTo<CategoryBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
