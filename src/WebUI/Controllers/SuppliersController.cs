using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TPProject.Application.Suppliers.Commands.UpdateSupplier;
using TPProject.Application.Suppliers.Commands.CreateSupplier;
using TPProject.Application.Suppliers.Queries.GetSuppliersWithPagination;
using TPProject.Application.Suppliers.Commands.DeleteSupplier;
using TPProject.Application.Common.Models;

namespace TPProject.WebUI.Controllers;

[Authorize]
public class SuppliersController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<SupplierBriefDto>>> GetSuppliersWithPagination([FromQuery] GetSuppliersWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateSupplierCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateSupplierCommand command)
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
        await Mediator.Send(new DeleteSupplierCommand { Id = id });

        return NoContent();
    }
}
