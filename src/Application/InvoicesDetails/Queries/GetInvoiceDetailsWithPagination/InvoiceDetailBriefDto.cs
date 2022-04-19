using TPProject.Application.Common.Mappings;
using TPProject.Domain.Entities;

namespace TPProject.Application.InvoicesDetails.Queries.GetInvoiceDetailsWithPagination;

public class InvoiceDetailBriefDto : IMapFrom<InvoiceDetail>
{
    public int Id { get; set; }
    public string? Brand { get; set; }
    public string? ProductName { get; set; }
    public string? SerialNumber { get; set; }
    public string? Description { get; set; }
    public decimal Cost { get; set; }
}
