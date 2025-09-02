using TG_Ecommerce.Domain.CategoryModel;
using TG_Ecommerce.SharedKernel.SeedWork;

namespace TG_Ecommerce.Domain.ProductModel;

public class Product : EntityBase<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}