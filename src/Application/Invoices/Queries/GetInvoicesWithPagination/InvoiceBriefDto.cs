using TPProject.Application.Common.Mappings;
using TPProject.Domain.Entities;

namespace TPProject.Application.Invoices.Queries.GetInvoicesWithPagination;

public class InvoiceBriefDto : IMapFrom<Invoice>
{
    public int Id { get; set; }

    public int InvoiceNumber { get; set; }

    public decimal Total { get; set; }

}
