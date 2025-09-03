using ECommerce_TG.Application.Products.Commands.AddProduct;
using ECommerce_TG.Application.Products.Queries.AllProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_TG.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductsController(IMediator mediator) : ControllerBase
{
    [HttpPost("addProduct")]
    public async Task<AddProductDto> CreateProduct([FromBody] AddProductCommand command, CancellationToken cancellationToken = default)
    {
        return await mediator.Send(command, cancellationToken);
    }
    
    [HttpGet("getAllProducts")]
    public async Task<List<AllProductDto>> AllProducts([FromQuery] AllProductQuery query, CancellationToken cancellationToken = default)
    {
        return await mediator.Send(query, cancellationToken);
    }
}