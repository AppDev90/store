using Microsoft.EntityFrameworkCore;
using Store.Core.Products.DataContract;
using Store.Core.Products.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Infrastructure.Data.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _storeDbContext;

        public ProductRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }

        public void Add(Product product)
        {
            _storeDbContext.Products.Add(product);
        }

        public Product Get(int id)
        {
            return _storeDbContext.Products.Find(id);
        }

        public async Task<IReadOnlyList<Product>> GetAll()
        {
            return await _storeDbContext
                .Products
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }
    }
}
