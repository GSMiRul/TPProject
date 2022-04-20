using AutoMapper;
using AutoMapper.QueryableExtensions;
using TPProject.Application.Common.Interfaces;
using TPProject.Application.Common.Mappings;
using TPProject.Application.Common.Models;
using MediatR;

namespace TPProject.Application.Suppliers.Queries.GetSuppliersWithPagination;

public class GetSuppliersWithPaginationQuery : IRequest<PaginatedList<SupplierBriefDto>>
{
    public int Id { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetSuppliersWithPaginationQueryHandler : IRequestHandler<GetSuppliersWithPaginationQuery, PaginatedList<SupplierBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSuppliersWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<SupplierBriefDto>> Handle(GetSuppliersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Suppliers
            .Where(x => x.Id == request.Id)
            .OrderBy(x => x.SuplierName)
            .ProjectTo<SupplierBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
