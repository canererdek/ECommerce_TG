using MediatR;

namespace ECommerce_TG.Application.Products.Commands.AddProduct;

public class AddProductCommand : IRequest<AddProductDto>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
}