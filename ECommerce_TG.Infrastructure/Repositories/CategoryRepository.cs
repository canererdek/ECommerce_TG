using Microsoft.EntityFrameworkCore;
using TG_Ecommerce.Domain.CategoryModel;
using TG_Ecommerce.Infrastructure.Context;

namespace TG_Ecommerce.Infrastructure.Repositories;

public class CategoryRepository(EcommerceDbContext context) : EfRepository<Category>(context), ICategoryRepository
{
    public async Task<bool> CheckCategoryName(string name)
    {
        return await context.Categories.AnyAsync(c=>c.Name.Trim() == name.Trim());
    }
}