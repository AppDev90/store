using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Core.Products.DataContract;
using Store.Core.Products.Dto.Query;
using Store.Core.Products.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Infrastructure.Data.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDbContext _storeDbContext;
        private readonly IConfiguration _configuration;

        public ProductRepository(StoreDbContext storeDbContext, IConfiguration configuration)
        {
            _storeDbContext = storeDbContext;
            _configuration = configuration;
        }

        public void Add(Product product)
        {
            _storeDbContext.Products.Add(product);
        }

        public Product Get(int id)
        {
            return _storeDbContext.Products.Find(id);
        }

        public async Task<IReadOnlyList<ProductsList>> GetAll()
        {
            return await _storeDbContext
                .Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .Select(p => new ProductsList()
                {
                    Id = p.Id,
                    ProductType = p.ProductType.Name,
                    Name = p.Name,
                    ProductBrand = p.ProductBrand.Name,
                    Description = p.Description,
                    PictureUrl = string.IsNullOrEmpty(p.PictureUrl) ?
                    "" : _configuration["ApiUrl"] + p.PictureUrl,
                    Price = p.Price,
                    ProductBrandId = p.ProductBrandId,
                    ProductTypeId = p.ProductTypeId
                })
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }
    }
}
