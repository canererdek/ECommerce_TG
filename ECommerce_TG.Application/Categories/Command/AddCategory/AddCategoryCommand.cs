using MediatR;

namespace ECommerce_TG.Application.Categories.Command.AddCategory;

public class AddCategoryCommand : IRequest<AddCategoryCommandDto>
{
    public string CategoryName { get; set; }
}