using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPProject.Application.Brands.Commands.CreateBrand;
using TPProject.Application.Brands.Commands.DeleteBrand;
using TPProject.Application.Brands.Commands.UpdateBrand;
using TPProject.Application.Brands.Queries.GetBrandsWithPagination;
using TPProject.Application.Common.Models;

namespace TPProject.WebUI.Controllers;

[Authorize]
public class BrandsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<BrandBriefDto>>> GetBrandsWithPagination([FromQuery] GetBrandsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateBrandCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateBrandCommand command)
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
        await Mediator.Send(new DeleteBrandCommand { Id = id });

        return NoContent();
    }
}
