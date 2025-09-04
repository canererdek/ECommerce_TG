using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TG_Ecommerce.Domain.CategoryModel;
using TG_Ecommerce.Domain.ProductModel;
using TG_Ecommerce.Infrastructure.Context;
using TG_Ecommerce.Infrastructure.Repositories;
using TG_Ecommerce.SharedKernel.SeedWork;

namespace TG_Ecommerce.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region Context
        // DbContext kaydı -> EF Core ile SQL Server kullanımı ayarlanıyor.
        // Connection string appsettings.json dosyasındaki "DefaultConnection" key’inden okunur.
        services.AddDbContext<EcommerceDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        #endregion

        #region Repositories
        // Repository kayıtları -> DI Container’a ekleniyor.
        // Scoped lifetime: Her HTTP request’te 1 instance oluşturulur.
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        

        #endregion

        return services;
    }
}