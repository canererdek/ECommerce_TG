namespace ECommerce_TG.Application.Products.Queries.AllProduct;

public class AllProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public CategoryDto Category { get; set; }
}

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}