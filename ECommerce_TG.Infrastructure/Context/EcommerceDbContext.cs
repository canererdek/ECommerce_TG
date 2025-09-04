using Microsoft.EntityFrameworkCore;
using TG_Ecommerce.Domain.CategoryModel;
using TG_Ecommerce.Domain.ProductModel;
using TG_Ecommerce.Infrastructure.EntityConfigurations;
using TG_Ecommerce.SharedKernel.SeedWork;

namespace TG_Ecommerce.Infrastructure.Context;

public class EcommerceDbContext : DbContext, IUnitOfWork
{
    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options)
        : base(options)
    {
    }

    // DbSet tanımları -> Veritabanında oluşturulacak tabloları temsil eder.
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    
    // Model oluşturma aşaması (Fluent API ile konfigürasyonlar burada yapılır).
    // EntityConfiguration sınıfları ile tabloların kolon ve ilişkileri detaylı şekilde ayarlanır.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
    }

    // UnitOfWork pattern'i ile veritabanı değişikliklerini kaydeden metod.
    // SaveChangesAsync çağırır ve değişikliklerin başarıyla kaydedilip kaydedilmediğini döner.
    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        return result > 0;
    }
}