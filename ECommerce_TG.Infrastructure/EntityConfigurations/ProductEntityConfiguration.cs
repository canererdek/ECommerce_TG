using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TG_Ecommerce.Domain.ProductModel;

namespace TG_Ecommerce.Infrastructure.EntityConfigurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        builder.Property(p => p.Stock).IsRequired();
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.CategoryId).IsRequired();
        // builder.Property(p => p.CreatedAt).IsRequired();
        // builder.Property(p => p.UpdatedAt);
        // builder.Property(p => p.DeletedAt);
    }
}