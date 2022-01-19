
using Store.Core.ProductBrands.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Core.ProductBrands.ServiceContract
{
    public interface IProductBrandService
    {
        Task<IReadOnlyList<ProductBrand>> GetAll();
    }
}
