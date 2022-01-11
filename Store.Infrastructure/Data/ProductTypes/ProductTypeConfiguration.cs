

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Core.ProductTypes.Entity;

namespace Store.Infrastructure.Data.ProductTypes
{
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.Property(p => p.Id)
                .IsRequired();
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
