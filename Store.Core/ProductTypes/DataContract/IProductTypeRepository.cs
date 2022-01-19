using Store.Core.ProductTypes.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Core.ProductTypes.DataContract
{
    public interface IProductTypeRepository
    {
        Task<IReadOnlyList<ProductType>> GetAll();
    }
}
