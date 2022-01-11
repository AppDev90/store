using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.Products.Entity;

namespace Store.Infrastructure.Data.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired();
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(p => p.Description)
                .IsRequired();
            builder.Property(p => p.Price)
                .HasConversion<decimal>()
                .HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureUrl)
                .IsRequired();
            
        }
    }
}
