using Store.Core.ProductBrands.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Core.ProductBrands.DataContract
{
    public interface IProductBrandRepository
    {
        Task<IReadOnlyList<ProductBrand>> GetAll();
    }
}
