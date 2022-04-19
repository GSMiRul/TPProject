using AutoMapper;
using AutoMapper.QueryableExtensions;
using TPProject.Application.Common.Interfaces;
using TPProject.Application.Common.Mappings;
using TPProject.Application.Common.Models;
using MediatR;

namespace TPProject.Application.Invoices.Queries.GetInvoicesWithPagination;

public class GetInvoicesWithPaginationQuery : IRequest<PaginatedList<InvoiceBriefDto>>
{
    public int Id { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetInvoicesWithPaginationQueryHandler : IRequestHandler<GetInvoicesWithPaginationQuery, PaginatedList<InvoiceBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetInvoicesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<InvoiceBriefDto>> Handle(GetInvoicesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Invoices
            .Where(x => x.Id == request.Id)
            .OrderBy(x => x.SupplierOrder.SuplierName)
            .ProjectTo<InvoiceBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
