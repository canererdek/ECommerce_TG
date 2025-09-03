using TG_Ecommerce.Domain.ProductModel;
using TG_Ecommerce.SharedKernel.SeedWork;

namespace TG_Ecommerce.Domain.CategoryModel;

public class Category : EntityBase<int>
{
    public string Name { get; private set; }
    public virtual List<Product> Products { get; set; }

    protected Category() { }

    public Category(string name)
    {
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }
}

