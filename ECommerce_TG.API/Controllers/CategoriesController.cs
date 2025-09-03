using ECommerce_TG.Application.Categories.Command.AddCategory;
using ECommerce_TG.Application.Categories.Queries.AllCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_TG.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpPost("addCategory")]
    public async Task<AddCategoryCommandDto> CreateCategory([FromBody] AddCategoryCommand command, CancellationToken cancellationToken = default)
    {
        return await mediator.Send(command, cancellationToken);
    }
    
    [HttpGet("getAllCategories")]
    public async Task<List<AllCategoryDto>> AllCategory([FromQuery] AllCategoryQuery query, CancellationToken cancellationToken = default)
    {
        return await mediator.Send(query, cancellationToken);
    }
}