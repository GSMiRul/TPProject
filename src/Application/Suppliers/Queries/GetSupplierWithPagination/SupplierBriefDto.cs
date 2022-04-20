using TPProject.Application.Common.Mappings;
using TPProject.Domain.Entities;

namespace TPProject.Application.Suppliers.Queries.GetSuppliersWithPagination;

public class SupplierBriefDto : IMapFrom<Supplier>
{
    public int Id { get; set; }

    public string? SuplierName { get; set; }

    public string? Address { get; set; }
}
