using AutoMapper;
using ECommerce_TG.Application.Products.Queries.AllProduct;
using TG_Ecommerce.Domain.ProductModel;

namespace ECommerce_TG.Application.Products.Maps;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, AllProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForPath(dest => dest.Category.Name, opt => opt.MapFrom(src => src.Category.Name))
            .ForPath(dest => dest.Category.Id, opt => opt.MapFrom(src => src.CategoryId));
    }
}