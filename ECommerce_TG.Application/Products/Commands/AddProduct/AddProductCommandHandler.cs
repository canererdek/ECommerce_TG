using MediatR;
using Microsoft.Extensions.Logging;
using TG_Ecommerce.Domain.CategoryModel;
using TG_Ecommerce.Domain.ProductModel;

namespace ECommerce_TG.Application.Products.Commands.AddProduct;

public class AddProductCommandHandler(
    ICategoryRepository categoryRepository,
    IProductRepository productRepository,
    ILogger<AddProductCommandHandler> logger) : IRequestHandler<AddProductCommand, AddProductDto>
{
    public async Task<AddProductDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        // 1. Ürün eklenmeden önce kategori var mı kontrol et
        var checkCategory = await categoryRepository.FirstOrDefaultAsync(x => x.Id == request.CategoryId);

        if (checkCategory is null)
        {
            // Kategori bulunamadıysa logla ve hata fırlat
            logger.LogInformation("Category not found");
            throw new ApplicationException("Category not found");
        }
        // 2. Yeni ürün nesnesi oluştur (domain entity)
        var product = new Product(request.Name,request.Price,request.Stock,checkCategory);
        await productRepository.AddAsync(product);
        var result = await productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        
        // 5. Başarılı ise logla
        if (result>0)
            logger.LogInformation($"Product created with product id:{product.Id}  at {product.CreatedAt.ToString()}");
        
        return new AddProductDto{Result = result>0};
    }
}