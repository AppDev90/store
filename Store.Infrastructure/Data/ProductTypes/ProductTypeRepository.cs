
using Microsoft.EntityFrameworkCore;
using Store.Core.ProductTypes.DataContract;
using Store.Core.ProductTypes.Entity;
using Store.Infrastructure.Data.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Infrastructure.Data.ProductTypes
{
    public class ProductTypeRepository : BaseStoreRepository, IProductTypeRepository
    {
        public ProductTypeRepository(StoreDbContext storeDbContext)
            : base(storeDbContext)
        {

        }

        public async Task<IReadOnlyList<ProductType>> GetAll()
        {
            return
                await StoreDbContext.ProductTypes
                .ToListAsync();
        }
    }
}
