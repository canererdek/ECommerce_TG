using ECommerce_TG.Application.Categories.Command.AddCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce_TG.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<AddCategoryCommandDto> CreateCategory([FromBody] AddCategoryCommand command, CancellationToken cancellationToken = default)
    {
        return await mediator.Send(command, cancellationToken);
    }
}