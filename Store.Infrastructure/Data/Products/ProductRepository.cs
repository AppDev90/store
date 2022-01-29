using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Store.Core.Products.DataContract;
using Store.Core.Products.Dto;
using Store.Core.Products.Dto.Query;
using Store.Core.Products.Entity;
using Store.Infrastructure.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.Infrastructure.Data.Products
{
    public class ProductRepository : BaseStoreRepository, IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(StoreDbContext storeDbContext, IConfiguration configuration)
            : base(storeDbContext)
        {
            _configuration = configuration;
        }

        public void Add(Product product)
        {
            StoreDbContext.Products.Add(product);
        }

        public Product Get(int id)
        {
            return StoreDbContext.Products.Find(id);
        }

        public async Task<IReadOnlyList<ProductsWithDetail>> GetProducts(FilterDto filterDto)
        {
            var query = StoreDbContext.Products
                .Where(GetWhereStatmentForFilter(filterDto))
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .AsSingleQuery();

            query = filterDto.Sort switch
            {
                "priceAsc" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                _ => query.OrderBy(p => p.Name),
            };

            query = query
                .Skip(filterDto.PageSize * (filterDto.PageIndex - 1))
                .Take(filterDto.PageSize);

            return await query
                .Select(p => new ProductsWithDetail()
                {
                    Id = p.Id,
                    ProductType = p.ProductType.Name,
                    Name = p.Name,
                    ProductBrand = p.ProductBrand.Name,
                    Description = p.Description,
                    PictureUrl = string.IsNullOrEmpty(p.PictureUrl) ?
                    "" : _configuration["ImageUrl"] + p.PictureUrl,
                    Price = p.Price,
                    ProductBrandId = p.ProductBrandId,
                    ProductTypeId = p.ProductTypeId
                })
                .AsNoTrackingWithIdentityResolution()
                .ToListAsync();
        }

        public async Task<int> GetCount(FilterDto filterDto)
        {
            return await StoreDbContext.Products
                .Where(GetWhereStatmentForFilter(filterDto))
                .CountAsync();
        }

        private Expression<Func<Product, bool>> GetWhereStatmentForFilter(FilterDto filterDto)
        {
            return (p => (!filterDto.BrandId.HasValue || p.ProductBrandId == filterDto.BrandId)
                         && (!filterDto.TypeId.HasValue || p.ProductTypeId == filterDto.TypeId)
                         && (string.IsNullOrEmpty(filterDto.Search) ||
                         p.Name.ToLower().Contains(filterDto.Search.ToLower()))
                         );
        }

        public async Task<ProductsWithDetail> GetWithDetail(int id)
        {
            return await StoreDbContext.Products
                 .Where(p => p.Id == id)
                 .Include(p => p.ProductBrand)
                 .Include(p => p.ProductType)
                 .Select(p => new ProductsWithDetail()
                 {
                     Id = p.Id,
                     ProductType = p.ProductType.Name,
                     Name = p.Name,
                     ProductBrand = p.ProductBrand.Name,
                     Description = p.Description,
                     PictureUrl = string.IsNullOrEmpty(p.PictureUrl) ?
                     "" : _configuration["ImageUrl"] + p.PictureUrl,
                     Price = p.Price,
                     ProductBrandId = p.ProductBrandId,
                     ProductTypeId = p.ProductTypeId
                 })
                 .SingleOrDefaultAsync();
        }
    }
}
