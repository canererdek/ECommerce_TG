using TG_Ecommerce.SharedKernel.SeedWork;

namespace TG_Ecommerce.Domain.CategoryModel;

public interface ICategoryRepository : IRepository<Category>
{
    Task<bool> CheckCategoryName(string name);
}