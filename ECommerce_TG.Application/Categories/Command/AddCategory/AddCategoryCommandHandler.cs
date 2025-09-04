using MediatR;
using Microsoft.Extensions.Logging;
using TG_Ecommerce.Domain.CategoryModel;

namespace ECommerce_TG.Application.Categories.Command.AddCategory;

public class AddCategoryCommandHandler(
    ICategoryRepository categoryRepository,
    ILogger<AddCategoryCommandHandler> logger) : IRequestHandler<AddCategoryCommand, AddCategoryCommandDto>
{
    public async Task<AddCategoryCommandDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        // 1. Aynı isimde kategori var mı kontrol et
        var checkCategory = await categoryRepository.CheckCategoryName(request.CategoryName);
        if (checkCategory)
        {
            // Eğer varsa logla ve başarısız DTO dön
            logger.LogInformation($"Category name is already exist:{request.CategoryName}");
            return new AddCategoryCommandDto{Result = false};
        }
            
        // 2. Yeni kategori nesnesi oluştur
        var newCategory = new Category(request.CategoryName);
        await categoryRepository.AddAsync(newCategory);
        
        // 5. Başarılı ise logla
        var result = await categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        if (result>0)
            logger.LogInformation($"Category created with category id:{newCategory.Id}  at {newCategory.CreatedAt.ToString()}");
        return new AddCategoryCommandDto{Result = result>0};
    }
}