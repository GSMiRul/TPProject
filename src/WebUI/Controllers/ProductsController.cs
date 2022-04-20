using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TPProject.Application.Common.Models;
using TPProject.Application.Products.Queries.GetProductsWithPagination;
using TPProject.Application.Products.Commands.CreateProduct;
using TPProject.Application.Products.Commands.UpdateProduct;
using TPProject.Application.Products.Commands.DeleteProduct;

namespace TPProject.WebUI.Controllers;

[Authorize]
public class ProductsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ProductBriefDto>>> GetProductsWithPagination([FromQuery] GetProductsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateProductCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateProductCommand command)
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
        await Mediator.Send(new DeleteProductCommand { Id = id });

        return NoContent();
    }
}
