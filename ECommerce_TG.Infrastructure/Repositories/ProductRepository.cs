using Microsoft.EntityFrameworkCore;
using TG_Ecommerce.Domain.ProductModel;
using TG_Ecommerce.Infrastructure.Context;

namespace TG_Ecommerce.Infrastructure.Repositories;

public class ProductRepository(EcommerceDbContext context) : EfRepository<Product>(context), IProductRepository
{
    public async Task<List<Product>> AllProductsWithCategoryAsync()
    {
        return await context.Products.Include(p=>p.Category).ToListAsync();
    }
}