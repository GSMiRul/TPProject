using AutoMapper;
using AutoMapper.QueryableExtensions;
using TPProject.Application.Common.Interfaces;
using TPProject.Application.Common.Mappings;
using TPProject.Application.Common.Models;
using MediatR;

namespace TPProject.Application.Brands.Queries.GetBrandsWithPagination;

public class GetBrandsWithPaginationQuery : IRequest<PaginatedList<BrandBriefDto>>
{
    public int Id { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetBrandsWithPaginationQueryHandler : IRequestHandler<GetBrandsWithPaginationQuery, PaginatedList<BrandBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetBrandsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<BrandBriefDto>> Handle(GetBrandsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Brands
            .Where(x => x.Id == request.Id)
            .OrderBy(x => x.BarandName)
            .ProjectTo<BrandBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
