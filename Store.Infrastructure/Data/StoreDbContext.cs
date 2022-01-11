
using Microsoft.EntityFrameworkCore;
using Store.Core.ProductBrands.Entity;
using Store.Core.Products.Entity;
using Store.Core.ProductTypes.Entity;
using System.Reflection;

namespace Store.Infrastructure.Data
{
    public class StoreDbContext : DbContext
    {

        public StoreDbContext(DbContextOptions<StoreDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
