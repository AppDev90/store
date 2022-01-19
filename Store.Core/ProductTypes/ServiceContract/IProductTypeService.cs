using Store.Core.ProductTypes.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Core.ProductTypes.ServiceContract
{
    public interface IProductTypeService
    {
        Task<IReadOnlyList<ProductType>> GetAll();
    }
}
