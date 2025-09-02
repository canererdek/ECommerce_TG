using TG_Ecommerce.Domain.CategoryModel;
using TG_Ecommerce.Infrastructure.Context;

namespace TG_Ecommerce.Infrastructure.Repositories;

public class CategoryRepository(EcommerceDbContext context) : EfRepository<Category>(context), ICategoryRepository
{
    
}