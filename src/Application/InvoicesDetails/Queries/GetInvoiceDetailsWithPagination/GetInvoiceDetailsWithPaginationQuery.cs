using AutoMapper;
using AutoMapper.QueryableExtensions;
using TPProject.Application.Common.Interfaces;
using TPProject.Application.Common.Mappings;
using TPProject.Application.Common.Models;
using MediatR;

namespace TPProject.Application.InvoicesDetails.Queries.GetInvoiceDetailsWithPagination;

public class GetInvoiceDetailsWithPaginationQuery : IRequest<PaginatedList<InvoiceDetailBriefDto>>
{
    public int Id { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetInvoiceDetailsWithPaginationQueryHandler : IRequestHandler<GetInvoiceDetailsWithPaginationQuery, PaginatedList<InvoiceDetailBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetInvoiceDetailsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<InvoiceDetailBriefDto>> Handle(GetInvoiceDetailsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.InvoiceDetails
            .Where(x => x.Id == request.Id)
            .OrderBy(x => x.BrandProduct.BarandName)
            .ThenBy(x => x.ProductInfo.ProductName)
            .ProjectTo<InvoiceDetailBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
