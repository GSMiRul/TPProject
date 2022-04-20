using AutoMapper;
using AutoMapper.QueryableExtensions;
using TPProject.Application.Common.Interfaces;
using TPProject.Application.Common.Mappings;
using TPProject.Application.Common.Models;
using MediatR;

namespace TPProject.Application.Products.Queries.GetProductsWithPagination;

public class GetProductsWithPaginationQuery : IRequest<PaginatedList<ProductBriefDto>>
{
    public int Id { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetProductsWithPaginationQueryHandler : IRequestHandler<GetProductsWithPaginationQuery, PaginatedList<ProductBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ProductBriefDto>> Handle(GetProductsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Products
            .Where(x => x.Id == request.Id)
            .OrderBy(x => x.ProductCategory.Name)
            .ThenBy(x => x.ProductName)
            .ProjectTo<ProductBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
