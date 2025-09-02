using TG_Ecommerce.Domain.ProductModel;
using TG_Ecommerce.SharedKernel.SeedWork;

namespace TG_Ecommerce.Domain.CategoryModel;

public class Category : EntityBase<int>
{
    public string Name { get; set; }
    public virtual List<Product> Products { get; set; }
}