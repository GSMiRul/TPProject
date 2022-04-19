using TPProject.Application.Common.Mappings;
using TPProject.Domain.Entities;

namespace TPProject.Application.Brands.Queries.GetBrandsWithPagination;

public class BrandBriefDto : IMapFrom<Brand>
{
    public int Id { get; set; }

    public int BrandName { get; set; }

    public string? ShortName { get; set; }
}
