using AutoMapper;
using ECommerce_TG.Application.Categories.Queries.AllCategory;
using TG_Ecommerce.Domain.CategoryModel;

namespace ECommerce_TG.Application.Categories.Maps;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, AllCategoryDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}