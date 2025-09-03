using AutoMapper;
using MediatR;
using TG_Ecommerce.Domain.ProductModel;

namespace ECommerce_TG.Application.Products.Queries.AllProduct;

public class AllProductQueryHandler(
    IProductRepository productRepository,
    IMapper mapper)  : IRequestHandler<AllProductQuery, List<AllProductDto>>
{
    public async Task<List<AllProductDto>> Handle(AllProductQuery request, CancellationToken cancellationToken)
    {
        var products = await productRepository.AllProductsWithCategoryAsync();
        return mapper.Map<List<AllProductDto>>(products);
    }
}