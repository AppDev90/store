

using Microsoft.EntityFrameworkCore;
using Store.Core.ProductBrands.DataContract;
using Store.Core.ProductBrands.Entity;
using Store.Infrastructure.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Infrastructure.Data.ProductBrands
{
    public class ProductBrandsRepository : BaseStoreRepository, IProductBrandRepository
    {
        public ProductBrandsRepository(StoreDbContext storeDbContext)
            : base(storeDbContext)
        {

        }

        public async Task<IReadOnlyList<ProductBrand>> GetAll()
        {
            return
                await StoreDbContext.ProductBrands
                .ToListAsync();
        }
    }
}
