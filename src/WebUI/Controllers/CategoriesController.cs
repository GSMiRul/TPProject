using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TPProject.Application.Common.Models;
using TPProject.Application.Categories.Queries.GetCategoriesWithPagination;
using TPProject.Application.Categories.Commands.CreateCategory;
using TPProject.Application.Categories.Commands.UpdateCategory;
using TPProject.Application.Categories.Commands.DeleteCategory;

namespace TPProject.WebUI.Controllers;

[Authorize]
public class CategoriesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<CategoryBriefDto>>> GetCategoriesWithPagination([FromQuery] GetCategoriesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateCategoryCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteCategoryCommand { Id = id });

        return NoContent();
    }
}
