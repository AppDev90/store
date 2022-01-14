using Store.Core.Products.Dto.Query;
using Store.Core.Products.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Core.Products.ServiceContract
{
    public interface IProductService
    {
        Product Get(int id);
        Task<IReadOnlyList<ProductsList>> GetAll();
        void Add(Product product);
    }
}
