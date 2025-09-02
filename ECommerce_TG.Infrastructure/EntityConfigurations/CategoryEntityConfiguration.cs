using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TG_Ecommerce.Domain.CategoryModel;

namespace TG_Ecommerce.Infrastructure.EntityConfigurations;

public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        // builder.Property(p => p.CreatedAt).IsRequired();
        // builder.Property(p => p.UpdatedAt);
        // builder.Property(p => p.DeletedAt);
    }
}