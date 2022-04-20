using TPProject.Application.Common.Mappings;
using TPProject.Domain.Entities;

namespace TPProject.Application.Products.Queries.GetProductsWithPagination;

public class ProductBriefDto : IMapFrom<Product>
{
    public int Id { get; set; }

    public int ProductName { get; set; }

    public string? Description { get; set; }
}
