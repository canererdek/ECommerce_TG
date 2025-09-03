using MediatR;
using TG_Ecommerce.Domain.CategoryModel;

namespace ECommerce_TG.Application.Categories.Command.AddCategory;

public class AddCategoryCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<AddCategoryCommand, AddCategoryCommandDto>
{
    public async Task<AddCategoryCommandDto> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var checkCategory = await categoryRepository.CheckCategoryName(request.CategoryName);
        if (checkCategory)
            return new AddCategoryCommandDto{Result = false};
        
        var newCategory = new Category(request.CategoryName);
        await categoryRepository.AddAsync(newCategory);
        
        var result = await categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return new AddCategoryCommandDto{Result = result>0};
    }
}