using AutoMapper;
using MediatR;
using TG_Ecommerce.Domain.CategoryModel;

namespace ECommerce_TG.Application.Categories.Queries.AllCategory;

public class AllCategoryQueryHandler(
    ICategoryRepository categoryRepository,
    IMapper mapper) :  IRequestHandler<AllCategoryQuery, List<AllCategoryDto>>
{
    public async Task<List<AllCategoryDto>> Handle(AllCategoryQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.ListAsync();
        return mapper.Map<List<AllCategoryDto>>(categories);
    }
}