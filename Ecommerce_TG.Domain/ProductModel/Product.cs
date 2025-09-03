using TG_Ecommerce.Domain.CategoryModel;
using TG_Ecommerce.SharedKernel.SeedWork;

namespace TG_Ecommerce.Domain.ProductModel;

public class Product : EntityBase<int>
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public int CategoryId { get; private set; }
    public Category Category { get; private set; }

    protected Product() { }

    public Product(string name, decimal price, int stock, Category category)
    {
        Name = name;
        Price = price;
        Stock = stock;
        CategoryId = category.Id;
        CreatedAt = DateTime.UtcNow;
    }
}