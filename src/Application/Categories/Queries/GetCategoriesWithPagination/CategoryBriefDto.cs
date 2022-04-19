using TPProject.Application.Common.Mappings;
using TPProject.Domain.Entities;

namespace TPProject.Application.Categories.Queries.GetCategoriesWithPagination;

public class CategoryBriefDto : IMapFrom<Category>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}
