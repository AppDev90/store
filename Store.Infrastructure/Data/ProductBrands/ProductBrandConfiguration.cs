

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.ProductBrands.Entity;

namespace Store.Infrastructure.Data.ProductBrands
{
    public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired();
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
